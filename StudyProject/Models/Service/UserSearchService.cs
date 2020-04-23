using StudyProject.Controllers.Form;
using StudyProject.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProject.Models.Service
{
    interface UserSearchService
    {
        List<UserDto> SearchUser(SearchForm searchForm);
    }
}
