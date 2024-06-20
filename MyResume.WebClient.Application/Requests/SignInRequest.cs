using System.ComponentModel.DataAnnotations;

namespace MyResume.WebClient.Application.Requests
{
    public class SignInRequest
    {
        public string Role { get; set; }
        [Required(ErrorMessage = "Обязательно поле для ввода")]
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Обязательно поле для ввода")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
