using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HackaGlobal.ViewModel
{
    public class UserLoginViewModel
    {
        [Display(Name = "نام کاربری (ایمیل)")]
        [DisplayName("نام کاربری (ایمیل)")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام کاربری (ایمیل) را وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "پسورد")]
        [DisplayName("پسورد")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "پسورد را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        [DisplayName("مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}