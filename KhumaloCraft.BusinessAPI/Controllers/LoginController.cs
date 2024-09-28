using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using KhumaloCraft.Business.Interfaces;
using KhumaloCraft.Data.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace KhumaloCraft.BusinessAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LoginController : ControllerBase
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;

    public LoginController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _tokenService = tokenService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      // Find the user by their email
      var user = await _userManager.FindByEmailAsync(model.Email);
      if (user == null)
        return Unauthorized("Invalid email or password");

      // Check the password
      var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
      if (!result.Succeeded)
        return Unauthorized("Invalid email or password");

      // Use the TokenService to generate the JWT token
      var token = _tokenService.GenerateToken(user.Id, user.Email, user.FirstName, user.LastName);

      return Ok(new { Token = token });
    }
  }

  public class LoginDTO
  {
    public string Email { get; set; }
    public string Password { get; set; }
  }
}
