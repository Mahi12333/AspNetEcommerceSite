using EcommerceProject.Repositories.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class AuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _jwtSecret;
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;

    public AuthorizationMiddleware(RequestDelegate next, IConfiguration configuration, IServiceProvider serviceProvider)
    {
        _next = next;
        _jwtSecret = configuration["JwtSettings:SecretKey"]
                      ?? throw new ArgumentException("JWT Secret Key is not configured properly in appsettings.json.");
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            if (!context.Request.Cookies.TryGetValue("AccessToken", out var accessToken))
            {
                await RedirectToUnauthorized(context, "Access token missing.");
                return;
            }

            var principal = ValidateJwtToken(accessToken);
            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                await RedirectToUnauthorized(context, "User ID not found in token.");
                return;
            }

            var endpoint = context.GetEndpoint();
            var authorizeAttributes = endpoint?.Metadata.GetOrderedMetadata<AuthorizeAttribute>() ?? Enumerable.Empty<AuthorizeAttribute>();
            var allowedRoles = authorizeAttributes
                .Where(attr => !string.IsNullOrEmpty(attr.Roles))
                .SelectMany(attr => attr.Roles.Split(','))
                .Select(role => role.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (allowedRoles.Any())
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var roleService = scope.ServiceProvider.GetRequiredService<IRoleService>();
                    var userRole = await roleService.GetRoleByUserIdAsync(userId);

                    if (userRole == null || !allowedRoles.Contains(userRole.Name, StringComparer.OrdinalIgnoreCase))
                    {
                        await RedirectToUnauthorized(context, "Access Denied: Insufficient Role.");
                        return;
                    }

                    context.Items["UserRoles"] = userRole;
                }
            }

            await _next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Authorization Middleware Error: {ex.Message}");
            await RedirectToUnauthorized(context, "An unexpected error occurred.");
        }
    }

    private ClaimsPrincipal ValidateJwtToken(string token)
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
            ClockSkew = TimeSpan.Zero
        };

        return tokenHandler.ValidateToken(token, validationParameters, out _);
    }

    private async Task RedirectToUnauthorized(HttpContext context, string message)
    {
        Console.WriteLine($"Authorization Middleware: {message}");
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        await context.Response.WriteAsync("Unauthorized: " + message);
    }
}
