using System.Collections.Generic;
using System.Linq;
using ASP.NET.Contexts;
using ASP.NET.Models;

namespace ASP.NET.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentContext _studentContext;

        public StudentService(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentContext.Students;
        }

        public Student GetById(int id)
        {
            return _studentContext.Students.First(x => x.Id == id);
        }

        public void Add(Student student)
        {
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _studentContext.Students.First(x => x.Id == id);
            _studentContext.Students.Remove(student);
            _studentContext.SaveChanges();
        }
    }
}
