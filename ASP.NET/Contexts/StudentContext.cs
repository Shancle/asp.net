using ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.Contexts
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Examinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
                .Property(exam => exam.Result)
                .IsRequired();
        }
    }
}
