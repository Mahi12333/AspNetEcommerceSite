using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceProject.middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _jwtSecret;
        private readonly IConfiguration _configuration;

        public AuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _jwtSecret = configuration["JwtSettings:SecretKey"]; // Secret key from configuration
            _configuration = configuration;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value;

            // Handle authentication
            if (context.Request.Cookies.TryGetValue("AccessToken", out var accessToken))
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(_jwtSecret);
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

                    var principal = tokenHandler.ValidateToken(accessToken, validationParameters, out _);
                    context.User = principal; // Attach user to HttpContext
                }
                catch
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized: Invalid or expired token.");
                    return;
                }
            }

            await _next(context);
        }


       /* public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value;

            // Allow unauthenticated access for the Customer area
            if (path != null && path.StartsWith("/customer", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("customer");
                await _next(context);
                return;
            }

            if (context.Request.Cookies.TryGetValue("AccessToken", out var accessToken))
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(_jwtSecret);

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

                    // Validate the token and get the principal
                    var principal = tokenHandler.ValidateToken(accessToken, validationParameters, out var validatedToken);

                    // Extract userId from the principal claims
                    var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    if (!string.IsNullOrEmpty(userId))
                    {
                        // Attach UserId to HttpContext for downstream middlewares
                        context.Items["UserId"] = userId;
                    }
                    else
                    {
                        context.Response.Redirect("/Admin/Unauthorized");
                        return;
                    }
                }
                catch
                {
                    // Token validation failed
                    context.Response.Redirect("/Admin/Unauthorized");
                    return;
                }
            }
            else
            {
                // No AccessToken found
                if (path != null && path.StartsWith("/admin", StringComparison.OrdinalIgnoreCase))
                {
                     context.Response.Redirect("/admin/login");

                    context.Response.Redirect("/Admin/Authentication/Login");
                    return;
                }
            }

            await _next(context);
        }
        */
    
    }
}
