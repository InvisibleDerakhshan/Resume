using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Account
{
    public class LoginViewModel
    {

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطقا {0} را وارد کنید ")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطقا {0} را وارد کنید ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public enum LoginResult
    {
        Success,
        Error,
        UserNotFound,

    }
}
