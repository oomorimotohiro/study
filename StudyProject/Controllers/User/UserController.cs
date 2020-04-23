using StudyProject.Controllers.Form;
using StudyProject.Models.Dto;
using StudyProject.Models.Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace StudyProject.Controllers.Home
{
    public class UserController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // ホーム画面を表示
            return View();
        }

        // GET: Search
        public ActionResult Search()
        {
            SearchForm SearchForm = new SearchForm();
            return View(SearchForm);
        }

        // POST: Search
        [HttpPost]
        public ActionResult Search(SearchForm SearchForm)
        {
            // 検索実施
            UserSearchServiceImpl service = new UserSearchServiceImpl();
            SearchForm.UserDtoList = service.SearchUser(SearchForm);
            return View(SearchForm);
        }

        // GET: Register
        public ActionResult Register()
        {
            RegisterForm RegisterForm = new RegisterForm();
            return View(RegisterForm);
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(RegisterForm RegisterForm)
        {
            

            return View(RegisterForm);
        }
    }
}