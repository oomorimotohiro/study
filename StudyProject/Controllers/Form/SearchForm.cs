using StudyProject.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyProject.Controllers.Form
{
    // 検索画面の入出力する値を格納する
    public class SearchForm
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserGender { get; set; }
        public string RegisterDate { get; set; }
        public string UpdateDate { get; set; }
        public IEnumerable<UserDto> UserDtoList { get; set; }
    }
}