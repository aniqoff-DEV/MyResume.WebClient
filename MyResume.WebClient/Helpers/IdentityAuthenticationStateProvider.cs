using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyResume.WebClient.Helpers
{
    public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public IdentityAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsStringAsync("token");

            if (!string.IsNullOrEmpty(token))
            {
                var tokenExtract = TokenHandler(token);

                var authUser = new ClaimsPrincipal(new ClaimsIdentity(
                    new List<Claim>()
                    {
                        new(ClaimTypes.Role, tokenExtract.Role),
                        new(ClaimTypes.NameIdentifier,tokenExtract.Id),
                    }, "jwt"));

                return new AuthenticationState(authUser);
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }

        public void MarkUserAsAuthenticated(string token)
        {
            var tokenExtract = TokenHandler(token);

            var authUser = new ClaimsPrincipal(new ClaimsIdentity(
                new List<Claim>
                {
                    new(ClaimTypes.Role, tokenExtract.Role),
                    new(ClaimTypes.NameIdentifier,tokenExtract.Id),
                }, "jwt"));

            var authState = Task.FromResult(new AuthenticationState(authUser));

            NotifyAuthenticationStateChanged(authState);
        }

        private (string Id, string Role) TokenHandler(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            // Access specific claims
            var idClaim = jwt.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var roleClaim = jwt.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Role);
                        
            return (idClaim.Value, roleClaim.Value);
        }
    }
}
