using System.ComponentModel.DataAnnotations;

namespace Blog.PresentationLayer.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User name is required!")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
    }
}