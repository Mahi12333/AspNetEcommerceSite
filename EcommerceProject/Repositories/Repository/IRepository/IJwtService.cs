using System.Security.Claims;

namespace EcommerceProject.Repositories.Repository.IRepository
{
    public interface IJwtService
    {
        string GenerateAccessToken(ApplicationUserModel user);
        string GenerateRefreshToken();
        ClaimsPrincipal ValidateToken(string token);
    }
}
