using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Inforce.BLL.Constants.Authentication;

namespace Inforce.BLL.DTO.Authentication.Login;

public class LoginRequestDTO
{
    [Required]
    [EmailAddress]
    [DefaultValue(AuthConstants.Email)]
    public string Login { get; set; }

    [Required]
    [DefaultValue(AuthConstants.Password)]
    [MaxLength(30, ErrorMessage = "Password maximum length is 30")]
    public string Password { get; set; }
}