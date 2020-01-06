using System.ComponentModel.DataAnnotations;

namespace Calendar.Server.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Необходимо ввести имя!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо ввести пароль!")]
        [DataType(DataType.Password, ErrorMessage = "Пароль введён неверно!")]
        public string Password { get; set; }
    }
}