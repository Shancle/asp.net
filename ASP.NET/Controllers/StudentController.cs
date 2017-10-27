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
        public void Create(Student student)
        {
            Students.Add(student);
        }

        [HttpPost]
        public void Update(Student student)
        {
            var oldStudent = Students.Single(x => x.Id == student.Id);
            oldStudent.Address = student.Address;
            oldStudent.Birthday = student.Birthday;
            oldStudent.Name = student.Name;
        }

        [HttpPost]
        public void Delete(int id)
        {
            Students.RemoveAll(x => x.Id == id);
        }
    }
}