using MyResume.WebClient.Application.Configurations;
using MyResume.WebClient.Application.Constants;
using MyResume.WebClient.Application.Contracts;
using MyResume.WebClient.Application.Responses.BranchResponses;
using System.Diagnostics;
using System.Text.Json;

namespace MyResume.WebClient.Application.Services
{
    public class BranchService : HttpClientService, IBranchService
    {
        public BranchService(HttpClient httpClient) : base(httpClient) => _url = BaseUrlConstant.BRANCH_URL;

        public async Task<List<BranchResponse>> GetAll()
        {
            List<BranchResponse?> branches = new();
            HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{BranchUrlConstant.GET_ALL}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                branches = JsonSerializer.Deserialize<List<BranchResponse?>>(content, _jsonSerializerOptions)!;
            }
            else
            {
                Debug.WriteLine("Ответ не соответсвует http 2xx");
            }
            return branches!;
        }
    }
}
