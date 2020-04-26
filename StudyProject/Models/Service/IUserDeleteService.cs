using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProject.Models.Service
{
    interface IUserDeleteService
    {
        /// <summary>
        /// ユーザ情報削除
        /// </summary>
        /// <param name="DelteUserId"></param>
        void DeleteUserWithPrimaryKeyUserId(string DelteUserId);
    }
}
