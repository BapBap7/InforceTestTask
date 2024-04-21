using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Inforce.DAL.Entities.Users;

public class User : IdentityUser
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(50)]
    public string Surname { get; set; }
}