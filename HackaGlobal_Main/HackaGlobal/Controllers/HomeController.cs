using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HackaGlobal.Models;
using HackaGlobal.Models.Interfaces;

namespace HackaGlobal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IUsersRepository _userRepository;
        public HomeController(IUnitOfWork db, IUsersRepository userRepository)
        {
            _db = db;
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
