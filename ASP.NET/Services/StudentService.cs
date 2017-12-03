using System;
using System.Collections.Generic;
using System.Linq;
using ASP.NET.Models;

namespace ASP.NET.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> Students = new List<Student>
        {
            new Student{ Id = 1, Name = "John", Address = "address1", Birthday = new DateTime(1999, 1, 2) },
            new Student{ Id = 2, Name = "Dave", Address = "address2", Birthday = new DateTime(2001, 3, 2) }
        };

        public IEnumerable<Student> GetAll()
        {
            return Students;
        }

        public Student GetById(int id)
        {
            return Students.First(x => x.Id == id);
        }

        public void Add(Student student)
        {
            Students.Add(student);
        }

        public void Delete(int id)
        {
            Students.RemoveAll(x => x.Id == id);
        }
    }
}
