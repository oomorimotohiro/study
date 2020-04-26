using StudyProject.Controllers.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProject.Models.Service
{
    interface IUserUpdateService
    {
        /// <summary>
        /// ユーザ情報の更新を実施
        /// </summary>
        /// <param name="EditForm"></param>
        void UpdateUserWithPrimaryKey(EditForm EditForm);
    }
}
