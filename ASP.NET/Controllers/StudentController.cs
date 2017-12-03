using ASP.NET.Models;
using ASP.NET.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NET.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ViewResult GetAll()
        {
            return View(_studentService.GetAll());
        }

        [HttpGet]
        public ViewResult Get(int id, [FromServices]IStudentService _studentService)
        {
            var student = _studentService.GetById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(student);
            }

            HttpContext.RequestServices.GetService<IStudentService>().Add(student);
            return Json(student);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            var oldStudent = _studentService.GetById(student.Id);
            oldStudent.Address = student.Address;
            oldStudent.Birthday = student.Birthday;
            oldStudent.Name = student.Name;
            oldStudent.Class = student.Class;
            return RedirectToAction("Get", "Student", new { id = student.Id });
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = _studentService.GetById(id);
            return View(student);
        }

        [HttpPost]
        public void Delete(int id)
        {
            ActivatorUtilities.CreateInstance<StudentService>(HttpContext.RequestServices).Delete(id);
        }
    }
}