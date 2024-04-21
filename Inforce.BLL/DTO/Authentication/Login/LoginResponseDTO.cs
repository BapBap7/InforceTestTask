using Inforce.BLL.DTO.Users;

namespace Inforce.BLL.DTO.Authentication.Login;

public class LoginResponseDTO
{
    public UserDTO User { get; set; }
    public string Token { get; set; }
    public DateTime ExpireAt { get; set; }
}