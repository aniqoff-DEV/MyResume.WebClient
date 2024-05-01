namespace MyResume.WebClient.Application.Configurations
{
    public struct BaseUrlConstant
    {
        public const string BASE_URL = "https://localhost:7169/";

        public const string JOBSEEKER_URL = $"{BASE_URL}JobSeeker";
        public const string LOCATION_URL = $"{BASE_URL}Location";
        public const string BRANCH_URL = $"{BASE_URL}Branch";
    }
}
