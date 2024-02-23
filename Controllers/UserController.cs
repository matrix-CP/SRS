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
   // [Route("[controller]")]
    public class UserController : Controller
    {
       private readonly IUserRepository _uh;

        public UserController(IUserRepository userRepository)
        {
            _uh = userRepository;
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

                _uh.Register(user);
                return RedirectToAction("Login", "User");
    
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(tblUser user)
        {
            
                _uh.Login(user);
                return RedirectToAction("Index", "Student");
           
            // if (_uh.Login(user))
            // {
            //     return RedirectToAction("Index", "Student");
            // }
            // return RedirectToAction("Login", "User");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}