using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SRS.Models;
using SRS.Repositories;

namespace SRS.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
       private readonly UserRepository _uh;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(UserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _uh = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(tblUser user)
        {
            if (ModelState.IsValid)
            {
                _uh.Register(user);
                return RedirectToAction("Login", "User");
            }
            return View(user);
        }

        public bool EmailExists(string email)
        {
            return _uh.EmailExists(email);
        }

        public bool ValidatePassword(string password)
        {
            return _uh.ValidatePassword(password);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(tblUser user)
        {
            if(ModelState.IsValid)
            {
                _uh.Login(user);
                return RedirectToAction("Index", "Student");
            }
            // if (_uh.Login(user))
            // {
            //     return RedirectToAction("Index", "Student");
            // }
            // return RedirectToAction("Login", "User");
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}