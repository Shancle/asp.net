using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ASP.NET.Contexts
{
    public class StudentContextFactory : IDesignTimeDbContextFactory<StudentContext>
    {
        public StudentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseNpgsql("Server=localhost; Database=aspnet; User Id=postgres; Password=q1w2e3R$;");
            return new StudentContext(optionsBuilder.Options);
        }
    }
}
