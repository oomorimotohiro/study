using StudyProject.Controllers.Form;
using StudyProject.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProject.Models.Service
{
    interface IUserSearchService
    {
        /// <summary>
        /// 検索画面の入力値で検索
        /// </summary>
        /// <param name="SearchForm"></param>
        /// <returns></returns>
        List<UserDto> SearchUser(SearchForm SearchForm);

        /// <summary>
        /// プライマリーキー「ユーザID」で検索
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        UserDto SearchUserWithPrimaryKeyUserId(string UserId);
    }
}
