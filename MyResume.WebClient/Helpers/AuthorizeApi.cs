using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MyResume.WebClient.Application.Contracts;
using MyResume.WebClient.Application.Requests;

namespace MyResume.WebClient.Helpers
{
    public class AuthorizeApi
    {
        private readonly IdentityAuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly IAuthorizationService _authorizationService;

        public AuthorizeApi(AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage, IAuthorizationService authorizationService)
        {
            _authenticationStateProvider = (IdentityAuthenticationStateProvider)authenticationStateProvider;
            _localStorage = localStorage;
            _authorizationService = authorizationService;
        }

        public async Task Login(SignInRequest request)
        {
            var token = await _authorizationService.SignIn(request);

            await _localStorage.SetItemAsStringAsync("token", token);

            _authenticationStateProvider.MarkUserAsAuthenticated(token);
        }
    }
}
