using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly AppDB _db;

    public AccountController(AppDB db)
    {
        _db = db;
    }

    [HttpPost]
    [Route("UserRegister")]
    public async Task<IActionResult> UserRegister()
    {

    }
  }
}