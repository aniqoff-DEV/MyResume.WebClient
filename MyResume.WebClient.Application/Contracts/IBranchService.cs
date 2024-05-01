using MyResume.WebClient.Application.Responses.BranchResponses;

namespace MyResume.WebClient.Application.Contracts
{
    public interface IBranchService
    {
        Task<List<BranchResponse>> GetAll();
    }
}
