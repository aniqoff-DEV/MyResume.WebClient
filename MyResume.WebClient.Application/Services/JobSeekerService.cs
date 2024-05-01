using MyResume.WebClient.Application.Configurations;
using MyResume.WebClient.Application.Contracts;
using MyResume.WebClient.Application.Exceptions;
using MyResume.WebClient.Application.Responses.JobSeekerResponses;
using System.Diagnostics;
using System.Text.Json;

namespace MyResume.WebClient.Application.Services
{
    public class JobSeekerService : HttpClientService, IJobSeekerService
    {
        public JobSeekerService(HttpClient httpClient) : base(httpClient)
        {
            _url = BaseUrlConstant.JOBSEEKER_URL;
        }

        public async Task<InfoOnPageJobSeekerResponse> GetInfoOnPageById(Guid jobSeekerId) ///
        {
            InfoOnPageJobSeekerResponse? jobSeeker = null;
            HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{JobSeekerUrlConstant.GET_PAGE_INFO_BY_ID}{jobSeekerId}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                jobSeeker = JsonSerializer.Deserialize<InfoOnPageJobSeekerResponse>(content, _jsonSerializerOptions)!;
            }
            else
            {
                Debug.WriteLine("Ответ не соответсвует http 2xx");
            }

            if (jobSeeker == null)
                throw new ResumeNotFoundException();

            return jobSeeker!;
        }

        public async Task<List<InfoOnCardJobSeekerResponse>> GetInfoOnCardOnList()
        {
            List<InfoOnCardJobSeekerResponse?> jobSeekerCards = new();
            HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{JobSeekerUrlConstant.GET_SMALL_INFO_ALL}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                jobSeekerCards = JsonSerializer.Deserialize<List<InfoOnCardJobSeekerResponse?>>(content, _jsonSerializerOptions)!;
            }
            else
            {
                Debug.WriteLine("Ответ не соответсвует http 2xx");
            }
            return jobSeekerCards!;
        }
    }
}
