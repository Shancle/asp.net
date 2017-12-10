using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET.Models
{
    public class Exam
    {
        public int Id { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }

        public int StudentId { get; set; }

        [Range(0, 5)]
        public int Result { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
