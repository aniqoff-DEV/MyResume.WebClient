using MyResume.WebClient.Application.Configurations;
using MyResume.WebClient.Application.Constants;
using MyResume.WebClient.Application.Contracts;
using MyResume.WebClient.Application.Exceptions;
using MyResume.WebClient.Application.Responses.CompanyResponses;
using MyResume.WebClient.Application.Responses.JobSeekerResponses;
using System.Diagnostics;
using System.Text.Json;

namespace MyResume.WebClient.Application.Services
{
    public class EmployerService : HttpClientService, IEmployerService
    {
        public EmployerService(HttpClient httpClient) : base(httpClient)
        {
            _url = BaseUrlConstant.EMPLOYER_URL;
        }

        public async Task<CompanyInfoResponse> GetCompanyCardById(Guid companyId)
        {
            CompanyInfoResponse? company = null;
            HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{EmployerUrlConstant.GET_COMPANY_BY_ID}{companyId}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                company = JsonSerializer.Deserialize<CompanyInfoResponse>(content, _jsonSerializerOptions)!;
            }
            else
            {
                Debug.WriteLine("Ответ не соответсвует http 2xx");
            }

            if (company == null)
                throw new CompanyNotFoundException();

            return company!;
        }

        public async Task<List<CompanyInfoResponse>> GetCompanyCards()
        {
            List<CompanyInfoResponse?> companyCards = new();
            HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{EmployerUrlConstant.GET_ALL_COMPANY}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                companyCards = JsonSerializer.Deserialize<List<CompanyInfoResponse?>>(content, _jsonSerializerOptions)!;
            }
            else
            {
                Debug.WriteLine("Ответ не соответсвует http 2xx");
            }
            return companyCards!;
        }
    }
}
