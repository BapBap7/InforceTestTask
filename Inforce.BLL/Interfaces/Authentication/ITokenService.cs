using System.IdentityModel.Tokens.Jwt;
using Inforce.DAL.Entities.Users;

namespace Inforce.BLL.Interfaces.Authentication;

public interface ITokenService
{
    public JwtSecurityToken GenerateJWTToken(User user);
}