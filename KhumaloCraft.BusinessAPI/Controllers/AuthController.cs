using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using KhumaloCraft.Business.Interfaces;
using KhumaloCraft.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using KhumaloCraft.Shared.DTOs;

namespace KhumaloCraft.BusinessAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;

    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _tokenService = tokenService;
    }

    // POST api/auth/login
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

      // Generate the JWT token for the user
      var token = _tokenService.GenerateToken(user.Id, user.Email, user.FirstName, user.LastName);

      return Ok(new { Token = token });
    }

    // POST api/auth/register
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterDTO model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      // Check if the email already exists
      var userExists = await _userManager.FindByEmailAsync(model.Email);
      if (userExists != null)
        return Conflict("A user with this email already exists");

      // Create a new user
      var user = new User
      {
        UserName = model.Email,
        Email = model.Email,
        FirstName = model.FirstName,
        LastName = model.LastName
      };

      // Create the user and hash the password
      var result = await _userManager.CreateAsync(user, model.Password);
      if (!result.Succeeded)
      {
        return BadRequest(result.Errors); // Return any errors if user creation fails
      }

      var token = _tokenService.GenerateToken(user.Id, user.Email, user.FirstName, user.LastName);
      return Ok(new { Token = token });
    }
  }
}
