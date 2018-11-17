namespace GraphqlApi.DbContexts
{
    using GraphqlApi.Models;
    using Microsoft.EntityFrameworkCore;

    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) 
        : base(options)
        {
        }

        public DbSet<Student> Students { get; set;}

        public DbSet<Course> Courses  { get; set;}

    }
}