using MyResume.WebClient.Application.Exceptions.Base;

namespace MyResume.WebClient.Application.Exceptions
{
    public class LoginOperationBadRequestException : BadRequestException
    {
        public LoginOperationBadRequestException(string message = "Empty request!") : base(message)
        {
        }
    }
}
