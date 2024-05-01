namespace MyResume.WebClient.Application.Responses.JobSeekerResponses
{
    public record InfoOnCardJobSeekerResponse(Guid Id, string FullName, string Description, string? BranchName, string? CityName, int? DesiredSalary);
}
