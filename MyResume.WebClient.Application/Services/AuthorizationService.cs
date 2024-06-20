using MyResume.WebClient.Application.Configurations;
using MyResume.WebClient.Application.Constants;
using MyResume.WebClient.Application.Contracts;
using MyResume.WebClient.Application.Exceptions;
using MyResume.WebClient.Application.Requests;
using MyResume.WebClient.Application.Responses;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyResume.WebClient.Application.Services
{
    public class AuthorizationService : HttpClientService, IAuthorizationService
    {
        public AuthorizationService(HttpClient httpClient) : base(httpClient) =>
            _url = BaseUrlConstant.AUTHORIZE_URL;

        public async Task<string> SignIn(SignInRequest request)
        {            
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_url}/{AuthorizeUrlConstant.SIGN_IN}", request);

            if (!response.IsSuccessStatusCode)
                throw new LoginOperationBadRequestException(await response.Content.ReadAsStringAsync());

            string content = await response.Content.ReadAsStringAsync();

            var token = JsonSerializer.Deserialize<TokenResponse>(content, _jsonSerializerOptions)!;

            if (string.IsNullOrEmpty(token.Token))
                throw new LoginOperationBadRequestException();

            return token.Token;
        }

        public async Task<string> SignUp(SignUpRequest request)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_url}/{AuthorizeUrlConstant.SIGN_UP}", request);

            if (!response.IsSuccessStatusCode)
                throw new LoginOperationBadRequestException(await response.Content.ReadAsStringAsync());

            string content = await response.Content.ReadAsStringAsync();

            var token = JsonSerializer.Deserialize<string>(content, _jsonSerializerOptions)!;

            if (string.IsNullOrEmpty(token))
                throw new LoginOperationBadRequestException();

            return token;
        }
    }
}
