using System.Text.Json;

namespace MyResume.WebClient.Application.Services
{
    public class HttpClientService
    {
        private protected readonly HttpClient _httpClient;
        private protected string _url;
        private protected readonly JsonSerializerOptions _jsonSerializerOptions;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
    }
}
