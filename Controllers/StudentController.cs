using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SRS.Models;

namespace SRS.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {

        private readonly StudentHelper _sh;
        private readonly CourseHelper _ch;
        private readonly ILogger<StudentController> _logger;

        public StudentController(StudentHelper studentHelper, CourseHelper courseHelper)
        {
            _sh = studentHelper;
            _ch = courseHelper;
        }

        public IActionResult Index()
        {
            string username = HttpContext.Session.GetString("username");
            if (username == null)
            {
                return RedirectToAction("Login","User");
            }
            ViewBag.Username = username;
            List<tblStudent> stuList = _sh.GetAllStudent();
            return View(stuList);
        }

        public IActionResult Details(int id)
        {
            if(HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "User");
            }
            tblStudent stu = _sh.GetOneStudent(id);
            return View(stu);
        }

        public IActionResult Add()
        {   
            if(HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.Course = _ch.GetAllCourse();
            return View();
        }

        // [HttpPost]
        // public IActionResult Add(tblStudent student)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View(student);
        //     }

        //     // Process valid form data here
        //         _sh.AddStudent(stu);
        //     return RedirectToAction("Index","Student");
        // }

        [HttpPost]
        public IActionResult Add(tblStudent stu)
        {
            if(HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login2","User");
            }
            if (!ModelState.IsValid)
            {
                return View(stu);
            }
            _sh.AddStudent(stu);
            return RedirectToAction("Index", "Student");
        }

        public IActionResult Edit(int id)
        {
            if(HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            ViewBag.Course = _ch.GetAllCourse();
            tblStudent stu = _sh.GetOneStudent(id);
            return View(stu);
        }

        [HttpPost]
        public IActionResult Edit(tblStudent stu)
        {
            if(HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "User");
            }
            if (!ModelState.IsValid)
            {
                return View(stu);
            }
            _sh.EditStudent(stu);
            return RedirectToAction("Index", "Student");
        }

        public IActionResult Delete(int id)
        {
            if(HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "User");
            }
            tblStudent stu = _sh.GetOneStudent(id);
            return View(stu);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "User");
            }

            tblStudent stu = _sh.GetOneStudent(id);

            if (stu != null)
            {
                _sh.DeleteStudent(stu);
            }
            else
            {
            }
            return RedirectToAction("Index","Student");
        }
    }
}