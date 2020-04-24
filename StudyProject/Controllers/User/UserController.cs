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
            UserSearchService service = new UserSearchService();
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
            if (!ModelState.IsValid)
            {
          　    // 入力チェックエラー
                return View(RegisterForm);
            } 

            // 登録実施
            UserRegisterService service = new UserRegisterService();
            service.RegisterUser(RegisterForm);
            return View(RegisterForm);
        }
    }
}