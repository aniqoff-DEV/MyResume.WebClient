using MyResume.WebClient.Application.Responses.VacancyResponses;

namespace MyResume.WebClient.Application.Contracts
{
    public interface IVacancyService
    {
        Task<List<InfoOnCardVacancyResponse>> GetInfoOnCardOnList();
        Task<InfoOnPageVacancyResponse> GetInfoOnPage(Guid vacancyId);
        Task<List<InfoOnCardVacancyResponse>> GetInfoOnCardOnListByEmployerId(Guid employerId);
    }
}