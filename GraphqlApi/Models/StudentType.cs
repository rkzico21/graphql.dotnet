namespace GraphqlApi.Models
{
    using GraphQL.Types;

    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType()
        {
            Name = "Student";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the student.");
            Field(x => x.Name).Description("The name of the student");
            Field(x => x.Courses, type: typeof(ListGraphType<CourseType>)).Description("Courses enrolled by student");
        }
    }
    
}