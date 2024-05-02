using MyResume.WebClient.Application.Exceptions.Base;

namespace MyResume.WebClient.Application.Exceptions
{
    public class VacancyNotFoundException : NotFoundException
    {
        public VacancyNotFoundException()
        : base($"Эта вакансия не найдена..")
        {

        }
    }
}
