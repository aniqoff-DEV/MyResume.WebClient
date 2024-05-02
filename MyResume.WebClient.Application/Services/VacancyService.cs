using MyResume.WebClient.Application.Configurations;
using MyResume.WebClient.Application.Constants;
using MyResume.WebClient.Application.Contracts;
using MyResume.WebClient.Application.Exceptions;
using MyResume.WebClient.Application.Responses.VacancyResponses;
using System.Diagnostics;
using System.Text.Json;

namespace MyResume.WebClient.Application.Services
{
    public class VacancyService : HttpClientService, IVacancyService
    {
        public VacancyService(HttpClient httpClient) : base(httpClient)
        {
            _url = BaseUrlConstant.VACANCY_URL;
        }

        public async Task<List<InfoOnCardVacancyResponse>> GetInfoOnCardOnList()
        {
            List<InfoOnCardVacancyResponse?> vacancyCards = new();
            HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{VacancyUrlConstant.GET_VACANCY_CARDS}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                vacancyCards = JsonSerializer.Deserialize<List<InfoOnCardVacancyResponse?>>(content, _jsonSerializerOptions)!;
            }
            else
            {
                Debug.WriteLine("Ответ не соответсвует http 2xx");
            }
            return vacancyCards!;
        }

        public async Task<List<InfoOnCardVacancyResponse>> GetInfoOnCardOnListByEmployerId(Guid employerId)
        {
            List<InfoOnCardVacancyResponse?> vacancyCards = new();
            HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{VacancyUrlConstant.GET_VACANCY_CARDS_BY_EMPLOYER_ID}{employerId}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                vacancyCards = JsonSerializer.Deserialize<List<InfoOnCardVacancyResponse?>>(content, _jsonSerializerOptions)!;
            }
            else
            {
                Debug.WriteLine("Ответ не соответсвует http 2xx");
            }
            return vacancyCards!;
        }

        public async Task<InfoOnPageVacancyResponse> GetInfoOnPage(Guid vacancyId)
        {
            InfoOnPageVacancyResponse? vacancyOnPage = null;
            HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{VacancyUrlConstant.GET_VACANCY_PAGE}{vacancyId}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                vacancyOnPage = JsonSerializer.Deserialize<InfoOnPageVacancyResponse?>(content, _jsonSerializerOptions)!;
            }
            else
            {
                Debug.WriteLine("Ответ не соответсвует http 2xx");
            }

            if (vacancyOnPage == null)
                throw new VacancyNotFoundException();

            return vacancyOnPage!;
        }
    }
}
