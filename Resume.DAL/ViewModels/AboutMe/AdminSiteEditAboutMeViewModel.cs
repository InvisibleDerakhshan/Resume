using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.AboutMe
{
    public class AdminSiteEditAboutMeViewModel
    {

        #region Properties
        public int Id { get; set; }

        [Display(Name = "نام")]
        [MaxLength(150,ErrorMessage ="تعداد کاراکتر وارد شده مجاز نمیباشد")]
        [Required(ErrorMessage = "لطقا {0} را وارد کنید ")]
  
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمیباشد")]
        [Required(ErrorMessage = "لطقا {0} را وارد کنید ")]
        public string? LastName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطقا {0} را وارد کنید ")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمیباشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string? Email { get; set; }


        [Display(Name = "موبایل")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمیباشد")]
        [Required(ErrorMessage = "لطقا {0} را وارد کنید ")]
        public string? Mobile { get; set; }

        [Display(Name = "بیوگرافی")]
        [MaxLength(800, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمیباشد")]
        [Required(ErrorMessage = "لطقا {0} را وارد کنید ")]
        public string? Bio { get; set; }

        [Display(Name = "سمت")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمیباشد")]
      
        public string? Position { get; set; }

        [Display(Name = "تاریخ تولد")]
 
        [Required(ErrorMessage = "لطقا {0} را وارد کنید ")]
        public DateOnly? BirthDate { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمیباشد")]
      
        public string? Location { get; set; }



        #endregion

    }

    public enum AdminSiteEditAboutMeResult
    {
       Success,
       Error,
       AboutMenotFound
    }
}
