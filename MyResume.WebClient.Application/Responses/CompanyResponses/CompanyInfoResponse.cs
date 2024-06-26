﻿namespace MyResume.WebClient.Application.Responses.CompanyResponses
{
    public class CompanyInfoResponse
    {
        public Guid Id { get; set; }
        public required string CompanyName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public float Reputation { get; set; }
        public int CountFeedBack { get; set; }

        public byte[]? Avatar { get; set; }
    }
}
