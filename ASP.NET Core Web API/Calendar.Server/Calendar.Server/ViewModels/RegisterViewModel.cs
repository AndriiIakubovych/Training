using System.ComponentModel.DataAnnotations;

namespace Calendar.Server.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Необходимо ввести имя!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо ввести почтовый адрес!")]
        [EmailAddress(ErrorMessage = "Почтовый адрес введён неверно!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Необходимо ввести пароль!")]
        [DataType(DataType.Password, ErrorMessage = "Пароль введён неверно!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Необходимо подтвердить пароль!")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        [DataType(DataType.Password, ErrorMessage = "Пароль введён неверно!")]
        public string PasswordConfirm { get; set; }
    }
}