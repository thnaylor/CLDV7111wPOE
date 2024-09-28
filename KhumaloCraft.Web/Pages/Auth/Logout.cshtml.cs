using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages.Auth
{
  public class LogoutModel : PageModel
  {
    public async Task<IActionResult> OnPostLogoutAsync()
    {
      // Sign out the user
      await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

      // Redirect to the home page after logout
      return RedirectToPage("/Index");
    }
  }
}
