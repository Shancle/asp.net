using System.Collections.Generic;
using ASP.NET.Models;

namespace ASP.NET.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Delete(int id);
    }
}
