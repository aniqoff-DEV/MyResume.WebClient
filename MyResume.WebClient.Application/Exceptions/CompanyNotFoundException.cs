using MyResume.WebClient.Application.Exceptions.Base;

namespace MyResume.WebClient.Application.Exceptions
{
    public class CompanyNotFoundException : NotFoundException
    {
        public CompanyNotFoundException() : base("Компания по вашему ресурсу не найдена")
        {
        }
    }
}
