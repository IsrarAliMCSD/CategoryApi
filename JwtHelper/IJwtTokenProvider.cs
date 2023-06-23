using Core_CategoryApi.Models;

namespace Core_CategoryApi.JwtHelper
{
    public interface IJwtTokenProvider
    {
        Tokens GenerateToken(User user);
    }
}
