using EcommerceProject.Repositories.Repository.IRepository;
using EcommerceProject.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


public class AuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _jwtSecret;
    private readonly IConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;

    public AuthorizationMiddleware(RequestDelegate next, IConfiguration configuration, IServiceProvider serviceProvider)
    {
        _next = next;
        _jwtSecret = configuration["JwtSettings:SecretKey"];
        _configuration = configuration;
        _serviceProvider = serviceProvider;
    }

    public async Task InvokeAsync(HttpContext context)
    {
       
        // Step 1: Check if the current endpoint has the MyAuthorization attribute
        var endpoint = context.GetEndpoint();
        Console.WriteLine($"endpoint: {endpoint}");
        if (endpoint == null)
        {
            // No endpoint metadata, proceed to the next middleware
            await _next(context);
            return;
        }

        var myAuthorizeAttributes = endpoint.Metadata.GetOrderedMetadata<MyAuthorizationAttribute>() ?? Enumerable.Empty<MyAuthorizationAttribute>();

        // If no MyAuthorization attribute is present, skip authentication
        if (!myAuthorizeAttributes.Any())
        {
            await _next(context);
            return;
        }

        // Step 2: AccessToken validation and role verification
        if (context.Request.Cookies.TryGetValue("AccessToken", out var accessToken))
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = System.Text.Encoding.UTF8.GetBytes(_jwtSecret);

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["JwtSettings:Issuer"],
                    ValidAudience = _configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.FromMinutes(5) // Allows a 5-minute skew
                };

                // Validate the token and attach claims to HttpContext.User
                var principal = tokenHandler.ValidateToken(accessToken, validationParameters, out var validatedToken);
                context.User = principal;

                foreach (var claim in context.User.Claims)
                {
                    Console.WriteLine($"{claim.Type}: {claim.Value}");
                }


                // Extract the userId from the JWT claims
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized: User not found in token.");
                    return;
                }

                // Step 3: Validate user role for MyAuthorization attribute
                var myAuthorizeAttribute = myAuthorizeAttributes.First();
                Console.WriteLine($"MyAuthorizationAttribute: {myAuthorizeAttribute.Roles}");
                // Check if the "User" role is present in the attribute and skip validation
                if (myAuthorizeAttribute.Roles?.Contains("User", StringComparer.OrdinalIgnoreCase) == true)
                {
                    // Skip validation for the "User" role
                    Console.WriteLine("Skipping role validation for 'User' role.");
                    await _next(context);
                    return;
                }

                if (myAuthorizeAttribute.Roles?.Length > 0)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var roleService = scope.ServiceProvider.GetRequiredService<IRoleService>();
                        var userRole = await roleService.GetRoleByUserIdAsync(userId);
                        Console.WriteLine($"User Role: {userRole}");
                        if (userRole == null)
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            await context.Response.WriteAsync("Access Denied: User Role not found.");
                            return;
                        }

                        // Check if user role matches any role in the attribute
                        var hasValidRole = myAuthorizeAttribute.Roles
                            .Any(role => role.Equals(userRole.Name, StringComparison.OrdinalIgnoreCase));

                        if (!hasValidRole)
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            // await context.Response.WriteAsync("Access Denied: Insufficient Role for Custom Attribute.");
                            await SetTempDataMessage(context, "Access Denied: Insufficient Role.");
                            context.Response.Redirect("/Admin/Authentication/AccessDenied");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync($"Unauthorized: {ex.Message}");
                return;
            }
        }
        else
        {
            // No access token found in cookies
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //await context.Response.WriteAsync("Unauthorized: No Access Token.");
            await SetTempDataMessage(context, "Unauthorized: No Access Token.");
            context.Response.Redirect("Authentication/Login");
            return;
        }

        // Proceed to the next middleware if everything is valid
        await _next(context);
    }




    private async Task SetTempDataMessage(HttpContext context, string message)
    {
        var tempDataFactory = context.RequestServices.GetRequiredService<ITempDataDictionaryFactory>();
        var tempData = tempDataFactory.GetTempData(context);
        Console.WriteLine($"tempData : {tempData}");
        tempData["ErrorMessage"] = message;
    }


}
