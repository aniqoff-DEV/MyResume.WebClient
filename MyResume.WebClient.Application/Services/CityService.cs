using MyResume.WebClient.Application.Configurations;
using MyResume.WebClient.Application.Constants;
using MyResume.WebClient.Application.Contracts;
using MyResume.WebClient.Application.Responses.LocationResponses;
using System.Diagnostics;
using System.Text.Json;

namespace MyResume.WebClient.Application.Services
{
    public class CityService : HttpClientService, ICityService
    {
        public CityService(HttpClient httpClient) : base(httpClient)
        {
            _url = BaseUrlConstant.LOCATION_URL;
        }

        public async Task<List<CityResponse>> GetAll(int countryId)
        {
            List<CityResponse?> cities = new();
            HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{CityUrlConstant.GET_ALL_BY_COUNTRY_ID}{countryId}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                cities = JsonSerializer.Deserialize<List<CityResponse?>>(content, _jsonSerializerOptions)!;
            }
            else
            {
                Debug.WriteLine("Ответ не соответсвует http 2xx");
            }
            return cities!;
        }
    }
}
