using MyResume.WebClient.Application.Responses.LocationResponses;

namespace MyResume.WebClient.Application.Contracts
{
    public interface ICityService
    {
        Task<List<CityResponse>> GetAll(int countryId);
    }
}
