using MyResume.WebClient.Application.Exceptions.Base;

namespace MyResume.WebClient.Application.Exceptions
{
    public class ResumeNotFoundException : NotFoundException
    {
        public ResumeNotFoundException()
        : base($"Это резюме не найдено..")
        {

        }
    }
}
