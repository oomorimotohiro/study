using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace StudyProject.Controllers.Form
{
    public class RegisterForm
    {
        [Required(ErrorMessage = "{0}を入力してください。")]
        [Display(Name = "ユーザID")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "{0}を入力してください。")]
        [Display(Name = "ユーザ名")]
        public string UserName { get; set; }

        public string UserGender { get; set; }

        [Required(ErrorMessage = "{0}を入力してください。")]
        [Display(Name = "パスワード")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0}を入力してください。")]
        [Display(Name = "確認用パスワード")]
        [Compare("Password", ErrorMessage = "入力されたパスワードと一致しません。")]
        public string ConfirmPassword { get; set; }
    }
}