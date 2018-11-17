namespace GraphqlApi.Queries
{
    using System.Linq;
    using GraphQL.Types;
    using GraphqlApi.DbContexts;
    using GraphqlApi.Models;
    using Microsoft.EntityFrameworkCore;
    
    public class StudentQuery : ObjectGraphType
    {
        public StudentQuery(StudentDbContext db)
        {
            Field<StudentType>(
                "student",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the student." }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var student = db
                        .Students
                        .Include(s=>s.Courses)
                        .FirstOrDefault(i => i.Id == id);
                    return student;
                });

            Field<ListGraphType<StudentType>>(
                "students",
                resolve: context =>
                {
                    var students = db.Students.Include(s=>s.Courses);
                    return students;
                });
        }
    }
}