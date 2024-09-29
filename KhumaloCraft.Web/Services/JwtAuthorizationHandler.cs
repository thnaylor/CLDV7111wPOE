using System.Net.Http.Headers;

namespace KhumaloCraft.Web.Services;

public class JwtAuthorizationHandler : DelegatingHandler
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public JwtAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }

  protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
  {
    var token = _httpContextAccessor.HttpContext.Request.Cookies["AuthToken"];

    if (!string.IsNullOrEmpty(token))
    {
      request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    return await base.SendAsync(request, cancellationToken);
  }
}
