using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
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
        if (EmailExist(UserModel.Email))
          return BadRequest("Email is used");

        if (!EmailValid(UserModel.Email))
          return BadRequest("Email is not valid");

        if (UserNameExist(UserModel.UserName))
          return BadRequest("UserName is used");

        AppUser user = new AppUser
        {
          UserName = UserModel.UserName,
          Email = UserModel.Email,
          PasswordHash = UserModel.Password
        };

        IdentityResult result = await _manager.CreateAsync(user, UserModel.Password);

        if (result.Succeeded)
          return StatusCode(StatusCodes.Status200OK);
        else
          return BadRequest(result.Errors);
      }

      return StatusCode(StatusCodes.Status400BadRequest);
    }

    private bool EmailValid(string email)
    {
      try
      {
        MailAddress checkedEmail = new MailAddress(email);
        return true;
      }
      catch (System.Exception)
      {
        return false;
      }
    }

    private bool UserNameExist(string userName)
    {
      return _db.Users.Any(u => u.UserName == userName);
    }

    private bool EmailExist(string email)
    {
      return _db.Users.Any(u => u.Email == email);
    }
  }
}