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
        public List<Student> Get()
        {
            return Students;
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
                return BadRequest(student);
            }

            var oldStudent = Students.Single(x => x.Id == student.Id);
            oldStudent.Address = student.Address;
            oldStudent.Birthday = student.Birthday;
            oldStudent.Name = student.Name;
            return Json(student);
        }

        [HttpPost]
        public void Delete(int id)
        {
            Students.RemoveAll(x => x.Id == id);
        }
    }
}