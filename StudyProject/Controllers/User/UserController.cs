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
            return View("Search", SearchForm);
        }

        // POST: Search
        [HttpPost]
        public ActionResult Search(SearchForm SearchForm)
        {
            // 検索実施
            UserSearchService service = new UserSearchService();
            SearchForm.UserDtoList = service.SearchUser(SearchForm);
            return View("Search", SearchForm);
        }

        // POST: Edit
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult Edit(string EditUserId, SearchForm SearchForm)
        {
            UserSearchService service = new UserSearchService();
            UserDto UserInfoDto = service.SearchUserWithPrimaryKeyUserId(EditUserId);
            if (UserInfoDto == null)
            {
                // 編集対象のユーザ情報がない場合、検索画面を再表示
                return View("Search", SearchForm);
            }

            EditForm EditForm = new EditForm();
            EditForm.UserId = UserInfoDto.UserId;
            EditForm.UserName = UserInfoDto.UserName;
            EditForm.UserGender = UserInfoDto.UserGender;

            return View(EditForm);
        }

        // POST: UPDATE
        [ActionName("UPDATE")]
        [HttpPost]
        public ActionResult Update(EditForm EditForm)
        {
            if (!ModelState.IsValid)
            {
                // 入力チェックエラー
                return View("Edit", EditForm);
            }

            return View(EditForm);
        }

        // POST: DELETE
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult Delete(string DeleteUserId, SearchForm SearchForm)
        {
            UserSearchService service = new UserSearchService();
            UserDto UserInfoDto = service.SearchUserWithPrimaryKeyUserId(DeleteUserId);
            if (UserInfoDto == null)
            {
                // 削除対象のユーザ情報がない場合、検索画面を再表示
                return View("Search", SearchForm);
            }

            return View();
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