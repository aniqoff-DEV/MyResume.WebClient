using System.ComponentModel.DataAnnotations;

namespace MyResume.WebClient.Application.Requests
{
    public class SignUpRequest
    {        
        public string Role { get; set; }
        [Required(ErrorMessage = "Обязательно поле для ввода")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обязательно поле для ввода")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Обязательно поле для ввода")]
        public string Password { get; set; }
        public int CityId { get; set; } = 0;
    }
}
