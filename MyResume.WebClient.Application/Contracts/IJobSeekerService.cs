﻿using MyResume.WebClient.Application.Responses.JobSeekerResponses;

namespace MyResume.WebClient.Application.Contracts
{
    public interface IJobSeekerService
    {
        Task<List<InfoOnCardJobSeekerResponse>> GetInfoOnCardOnList();
        Task<InfoOnPageJobSeekerResponse> GetInfoOnPageById(Guid jobSeekerId);
    }
}
