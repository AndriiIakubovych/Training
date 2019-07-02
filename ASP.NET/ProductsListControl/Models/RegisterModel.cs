using System.ComponentModel.DataAnnotations;

namespace ProductsListControl.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Логин обязателен для ввода!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Почтовый адрес обязателен для ввода!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пароль обязателен для ввода!")]
        [DataType(DataType.Password)]
        [MinLength(length: 6, ErrorMessage = "Длина пароля должна быть не менее 6 символов!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Необходимо подтвердить пароль!")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}