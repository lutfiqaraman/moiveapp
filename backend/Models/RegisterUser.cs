using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
  public class RegisterUser
  {
    [StringLength(256), Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
  }
}