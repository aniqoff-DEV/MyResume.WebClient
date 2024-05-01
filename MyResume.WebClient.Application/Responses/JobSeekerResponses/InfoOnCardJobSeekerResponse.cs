namespace MyResume.WebClient.Application.Responses.JobSeekerResponses
{
    public record InfoOnCardJobSeekerResponse(
        Guid Id,
        string FullName, 
        string Description,
        byte[]? Avatar,
        string? BranchName,
        string? CityName,
        int? DesiredSalary);
}
