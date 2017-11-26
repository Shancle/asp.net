using System;
using System.Collections.Generic;
using System.Linq;
using ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> Students = new List<Student>
        {
            new Student{ Id = 1, Name = "John", Address = "address1", Birthday = new DateTime(1999, 1, 2) },
            new Student{ Id = 2, Name = "Dave", Address = "address2", Birthday = new DateTime(2001, 3, 2) }
        };

        [HttpGet]
        public ViewResult GetAll()
        {
            return View(Students);
        }

        [HttpGet]
        public ViewResult Get(int id)
        {
            var student = Students.Single(x => x.Id == id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(student);
            }

            Students.Add(student);
            return Json(student);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            var oldStudent = Students.Single(x => x.Id == student.Id);
            oldStudent.Address = student.Address;
            oldStudent.Birthday = student.Birthday;
            oldStudent.Name = student.Name;
            oldStudent.Class = student.Class;
            return RedirectToAction("Get", "Student", new { id = student.Id });
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = Students.Single(x => x.Id == id);
            return View(student);
        }

        [HttpPost]
        public void Delete(int id)
        {
            Students.RemoveAll(x => x.Id == id);
        }
    }
}