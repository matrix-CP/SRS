using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SRS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRS.Repositories;
namespace SRS.Controllers
{
    //[Route("[controller]")]
    public class StudentController : Controller
    {

        private readonly IStudentRepository _sh;
        private readonly IUserRepository _ch;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentRepository studentHelper, IUserRepository courseHelper)
        {
            _sh = studentHelper;
            _ch = courseHelper;
        }

        public IActionResult Index()
        {
            // string username = HttpContext.Session.GetString("username");
            // if (username == null)
            // {
            //     return RedirectToAction("Login","User");
            // }
            // ViewBag.Username = username;
            List<tblStudent> stuList = _sh.FetchAllStudents();
            return View(stuList);
        }

        public IActionResult Details(int id)
        {
            // if(HttpContext.Session.GetString("username") == null)
            // {
            //     return RedirectToAction("Login", "User");
            // }
            tblStudent stu = _sh.FetchStudentDetails(id);
            return View(stu);
        }

        public IActionResult Add()
        {  
            // if(HttpContext.Session.GetString("username") == null)
            // {
            //     return RedirectToAction("Login", "User");
            // }
            // ViewBag.Course = _sh.GetAllCourse();
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
            // if(HttpContext.Session.GetString("username") == null)
            // {
            //     return RedirectToAction("Login2","User");
            // }
            _sh.InsertStudent(stu);
            return RedirectToAction("Index", "Student");
        }

        public IActionResult Edit(int id)
        {
            // if(HttpContext.Session.GetString("username") == null)
            // {
            //     return RedirectToAction("Login", "User");
            // }

            ViewBag.Course = _sh.GetAllCourse();
            tblStudent stu = _sh.FetchStudentDetails(id);
            return View(stu);
        }

        [HttpPost]
        public IActionResult Edit(tblStudent stu)
        {
            // if(HttpContext.Session.GetString("username") == null)
            // {
            //     return RedirectToAction("Login", "User");
            // }
            _sh.UpdateExistingStudent(stu);
            return RedirectToAction("Index", "Student");
        }

       

    
        public IActionResult Delete(int id)
        {
            // if (HttpContext.Session.GetString("username") == null)
            // {
            //     return RedirectToAction("Login", "User");
            // }

            
                _sh.DeleteStudentDetails(id);
            
            return RedirectToAction("Index","Student");
        }

        public IActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AjaxAdd([FromBody]tblStudent student)
        {
            Console.WriteLine("Language is: "+student.c_language);
            _sh.InsertStudent(student);
            return Json(new{message="Student Added Successfully!",status=true});
        }

        public IActionResult AjaxDetails(int id)
        {
            // if(HttpContext.Session.GetString("username") == null)
            // {
            //     return RedirectToAction("Login", "User");
            // }
            tblStudent student = _sh.FetchStudentDetails(id);
            return Json(student);
        }
        [HttpPost]
        public IActionResult AjaxEdit([FromBody]tblStudent student)
        {
            // if(HttpContext.Session.GetString("username") == null)
            // {
            //     return RedirectToAction("Login", "User");
            // }
            _sh.UpdateExistingStudent(student);
            return Json(new{message="Updated Sucessfully!",status=true});
        }

        public IActionResult AjaxDelete(int id)
        {
            // if (HttpContext.Session.GetString("username") == null)
            // {
            //     return RedirectToAction("Login", "User");
            // }

            
            _sh.DeleteStudentDetails(id);
            
            return Json(new{message="Deleted Successully!",status=true});
        }
        public IActionResult GetAllStudents()
        {
            List<tblStudent> students=_sh.FetchAllStudents();
            return Json(students);
        }
    }
}