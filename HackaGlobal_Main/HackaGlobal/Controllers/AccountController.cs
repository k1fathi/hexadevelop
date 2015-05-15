using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HackaGlobal.Models;
using HackaGlobal.Models.Interfaces;
using HackaGlobal.ViewModel;

namespace HackaGlobal.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IUsersRepository _userRepository;

        public AccountController(IUnitOfWork db, IUsersRepository userRepository)
        {
            _db = db;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var a = User.Identity.IsAuthenticated;
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new UserLoginViewModel());
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserLoginViewModel obj)
        {
            var user = _userRepository.Exist(obj.Email, obj.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), obj.RememberMe);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "نام کاربری یا پسورد اشتباه است";
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}
