using EcommerceProject.Repositories.Repository.IRepository;
using EcommerceProject.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class PermissionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _jwtSecret;
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;

    public PermissionMiddleware(RequestDelegate next, IConfiguration configuration, IServiceProvider serviceProvider)
    {
        _next = next;
        _jwtSecret = configuration["JwtSettings:SecretKey"];
        _serviceProvider = serviceProvider;
        _configuration = configuration;
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
                };

                var principal = tokenHandler.ValidateToken(accessToken, validationParameters, out var validatedToken);

                if (validatedToken is JwtSecurityToken)
                {
                    var endpoint = context.GetEndpoint();
                    if (endpoint == null || !endpoint.Metadata.Any())
                    {
                        await _next(context);
                        return;
                    }

                    var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    if (string.IsNullOrEmpty(userId))
                    {
                        context.Response.Redirect("/Admin/Unauthorized");
                        return;
                    }

                    // Resolve scoped service (IPermissionService) at runtime
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var permissionService = scope.ServiceProvider.GetRequiredService<IPermissionService>();
                        var userPermissions = await permissionService.GetPermissionsForUserAsync(userId);

                        if (userPermissions == null || !userPermissions.Any())
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            await context.Response.WriteAsync("Access Denied: No permissions assigned.");
                            return;
                        }

                        var permissionAttributes = endpoint.Metadata.GetOrderedMetadata<PermissionAttribute>();
                        var requiredPermissions = permissionAttributes.SelectMany(attr => attr.Permissions).Distinct();

                        if (!requiredPermissions.All(rp => userPermissions.Select(p => p.PermissionName).Contains(rp)))
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            await context.Response.WriteAsync("Access Denied: Insufficient permissions.");
                            return;
                        }

                        context.Items["UserPermissions"] = userPermissions;
                    }

                    await _next(context);
                }
                else
                {
                    context.Response.Redirect("/Admin/Unauthorized");
                    return;
                }
            }
            catch (SecurityTokenException ex)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync($"Unauthorized: {ex.Message}");
                return;
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"Internal Server Error: {ex.Message}");
                return;
            }
        }
        else
        {
            context.Response.Redirect("/Admin/Unauthorized");
            return;
        }
    }
}
