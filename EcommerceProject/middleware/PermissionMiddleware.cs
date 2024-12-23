using EcommerceProject.Repositories.Repository.IRepository;
using EcommerceProject.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class PermissionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _jwtSecret;
    private readonly IConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;

    public PermissionMiddleware(RequestDelegate next, IConfiguration configuration, IServiceProvider serviceProvider)
    {
        _next = next;
        _jwtSecret = configuration["JwtSettings:SecretKey"];
        _configuration = configuration;
        _serviceProvider = serviceProvider;
    }

    public async Task InvokeAsync(HttpContext context)
    {
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

                // Extract the userId from the JWT claims
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    // If no userId is found in the JWT, return Unauthorized
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized: User not found in token.");
                    return;
                }

                // Step 1: Extract the required permissions from the Permission attribute
                var endpoint = context.GetEndpoint();
                var permissionAttributes = endpoint?.Metadata.GetOrderedMetadata<PermissionAttribute>() ?? Enumerable.Empty<PermissionAttribute>();
                var requiredPermissions = permissionAttributes.SelectMany(attr => attr.Permissions).Distinct();

                if (requiredPermissions.Any())
                {
                    // Step 2: Use IPermissionService to fetch the user permissions from the database
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var permissionService = scope.ServiceProvider.GetRequiredService<IPermissionService>();
                        var userPermissions = await permissionService.GetPermissionsForUserAsync(userId);

                        // Step 3: Check if the user has the required permissions
                        if (userPermissions == null || !userPermissions.Any())
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            //await context.Response.WriteAsync("Access Denied: No permissions assigned.");
                            context.Response.Redirect("/Admin/Authentication/AccessDenied");
                            return;
                        }

                        // Step 4: Check if the user has all required permissions
                        if (!requiredPermissions.All(rp => userPermissions.Select(p => p.PermissionName).Contains(rp)))
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            //await context.Response.WriteAsync("Access Denied: Insufficient permissions.");
                            context.Response.Redirect("/Admin/Authentication/AccessDenied");
                            return;
                        }

                        // Step 5: Optionally, you can store the permissions for further use in the request
                        context.Items["UserPermissions"] = userPermissions;
                    }
                }
            }
            catch (Exception ex)
            {
                // Step 6: Token validation failure or expired token
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync($"Unauthorized: {ex.Message}");
                return;
            }
        }
        //else
        //{
        //    // If no token is found, return Unauthorized
        //    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        //    await context.Response.WriteAsync("Unauthorized: No access token found.");
        //    return;
        //}

        // Proceed to the next middleware if permission checks pass
        await _next(context);
    }
}
