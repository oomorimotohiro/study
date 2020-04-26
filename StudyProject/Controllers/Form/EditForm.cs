using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyProject.Controllers.Form
{
    public class EditForm
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "{0}を入力してください。")]
        [Display(Name = "ユーザ名")]
        public string UserName { get; set; }

        public string UserGender { get; set; }
    }
}