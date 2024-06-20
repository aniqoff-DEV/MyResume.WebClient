namespace MyResume.WebClient.Application.Exceptions.Base
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message) : base(message)
        {

        }
    }
}
