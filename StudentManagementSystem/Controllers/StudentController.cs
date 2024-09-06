using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;

        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.RegisterStudentAsync(student);
                return RedirectToAction("Index", "Home");
            }
            return View(student);
        }

        public ActionResult RegisterStudent()
        {
            return View();
        }

        public ActionResult LoginStudent() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logout(Login login) 
        {
            var loginDetails = _studentRepository.LoginStudentAsync(login);
            if (loginDetails != null) { return Ok(); }
                return RedirectToAction("Index", "Home");
        }
    }
}
