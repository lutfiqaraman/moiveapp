using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
  public class RegisterUser
  {
    [StringLength(256), Required]
    public string UserName { get; set; }

    [StringLength(256), Required, DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
  }
}