using StudyProject.Controllers.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProject.Models.Service
{
    interface IUserRegisterService
    {
        void RegisterUser(RegisterForm RegisterForm);
    }
}
