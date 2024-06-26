﻿namespace MyResume.WebClient.Application.Responses.VacancyResponses
{
    public class InfoOnPageVacancyResponse
    {
        public Guid Id { get; set; }
        public Guid EmployerId { get; set; }
        public required string CompanyName { get; set; }
        public required string Description { get; set; }
        public required string BranchName { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public byte[]? Avatar { get; set; }

        public required string Experience { get; set; }
        public required string Employment { get; set; }
        public required string ScheduleWork { get; set; }
        public required int Salary { get; set; }
        public byte[]? File { get; set; }
    }
}
