using System.ComponentModel.DataAnnotations;

namespace ProductsListControl.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Логин обязателен для ввода!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Пароль обязателен для ввода!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}