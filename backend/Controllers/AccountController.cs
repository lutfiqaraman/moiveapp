using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly AppDB _db;
    private readonly UserManager<AppUser> _manager;

    public AccountController(AppDB db, UserManager<AppUser> manager)
    {
      _db = db;
      _manager = manager;
    }

    [HttpPost]
    [Route("UserRegister")]
    public async Task<IActionResult> UserRegister(RegisterUser UserModel)
    {
      if (UserModel == null)
        NotFound();

      if (ModelState.IsValid)
      {
        if (!EmailExist(UserModel.Email))
          return BadRequest("Email is not avaliable");

        AppUser user = new AppUser
        {
          Email = UserModel.Email,
          PasswordHash = UserModel.Password
        };

        IdentityResult result = await _manager.CreateAsync(user);

        if (result.Succeeded)
          return StatusCode(StatusCodes.Status200OK);
      }

      return StatusCode(StatusCodes.Status400BadRequest);
    }

    private bool EmailExist(string email)
    {
      return _db.Users.Any(u => u.Email == email);
    }
  }
}