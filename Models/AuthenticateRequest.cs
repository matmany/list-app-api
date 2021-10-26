using System.ComponentModel.DataAnnotations;

namespace ListApi.Models.Users
{
  public class AuthenticateRequest
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }
  }
}