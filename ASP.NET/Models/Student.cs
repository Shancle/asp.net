using System;
using System.ComponentModel.DataAnnotations;
using ASP.NET.Infrastructure.Attributes;

namespace ASP.NET.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime Birthday { get; set; }

        [ClassValidation]
        public int? Class { get; set; }
    }
}
