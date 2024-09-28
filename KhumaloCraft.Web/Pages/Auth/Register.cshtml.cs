using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;
using System;
using KhumaloCraft.Shared.DTOs;

namespace KhumaloCraft.Pages.Auth
{
  public class RegisterModel : PageModel
  {
    private readonly HttpClient _httpClient;
    private readonly ILogger<RegisterModel> _logger;

    // Bind the RegisterDTO to handle form data from Razor Page
    [BindProperty]
    public RegisterDTO RegisterDTO { get; set; }

    public string ErrorMessage { get; set; }

    public RegisterModel(IHttpClientFactory httpClientFactory, ILogger<RegisterModel> logger)
    {
      _httpClient = httpClientFactory.CreateClient("BusinessAPI");
      _logger = logger;
    }

    public IActionResult OnGet()
    {
      if (User.Identity.IsAuthenticated)
      {
        return RedirectToPage("/Index");
      }

      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      // First, check if the passwords match
      if (RegisterDTO.Password != RegisterDTO.ConfirmPassword)
      {
        ModelState.AddModelError("RegisterDTO.ConfirmPassword", "The password and confirmation password do not match.");
        return Page();
      }

      if (!ModelState.IsValid)
      {
        return Page();
      }

      // Prepare registration data
      var registerData = new
      {
        FirstName = RegisterDTO.FirstName,
        LastName = RegisterDTO.LastName,
        Email = RegisterDTO.Email,
        Password = RegisterDTO.Password
      };

      // Send registration request to the API
      var jsonContent = new StringContent(JsonSerializer.Serialize(registerData), Encoding.UTF8, "application/json");
      var response = await _httpClient.PostAsync("api/auth/register", jsonContent);

      if (response.IsSuccessStatusCode)
      {
        // Parse the token response
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonSerializer.Deserialize<TokenResponseDTO>(jsonResponse, new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true
        });

        // Store the JWT token in cookies
        HttpContext.Response.Cookies.Append("AuthToken", tokenResponse.Token, new CookieOptions
        {
          HttpOnly = true, // Prevent client-side access to the cookie for security
          Expires = DateTimeOffset.UtcNow.AddHours(1) // Token expires in 1 hour
        });

        // Redirect to a protected page or homepage after successful registration
        return RedirectToPage("/Index");
      }
      else
      {
        // Log the error and display a message to the user
        ErrorMessage = "Registration failed. Please try again.";
        _logger.LogWarning("Failed registration attempt for user: {Email}", RegisterDTO.Email);
        return Page();
      }
    }
  }
}
