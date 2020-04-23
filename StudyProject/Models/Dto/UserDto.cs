using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyProject.Models.Dto
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserGender { get; set; }
        public string RegisterDate { get; set; }
        public string UpdateDate { get; set; }
    }
}