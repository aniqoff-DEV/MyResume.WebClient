using MyResume.WebClient.Application.Requests;

namespace MyResume.WebClient.Application.Contracts
{
    public interface IAuthorizationService
    {
        public Task<string> SignIn(SignInRequest request);
        public Task<string> SignUp(SignUpRequest request);
    }
}
