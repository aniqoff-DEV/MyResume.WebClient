﻿namespace MyResume.WebClient.Application.Configurations
{
    public struct BaseUrlConstant
    {
        public const string BASE_URL = "https://localhost:7169/";

        public const string JOBSEEKER_URL = $"{BASE_URL}JobSeeker";
        public const string LOCATION_URL = $"{BASE_URL}Location";
        public const string BRANCH_URL = $"{BASE_URL}Branch";
        public const string VACANCY_URL = $"{BASE_URL}Vacancy";
        public const string EMPLOYER_URL = $"{BASE_URL}Employer";
        public const string AUTHORIZE_URL = $"{BASE_URL}Authorization";
    }
}
