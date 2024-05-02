using MyResume.WebClient.Application.Responses.CompanyResponses;

namespace MyResume.WebClient.Application.Contracts
{
    public interface IEmployerService
    {
        Task<CompanyInfoResponse> GetCompanyCardById(Guid employerId);
        Task<List<CompanyInfoResponse>> GetCompanyCards();
    }
}
