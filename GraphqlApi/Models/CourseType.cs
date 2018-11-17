namespace GraphqlApi.Models
{
    using GraphQL.Types;

    public class CourseType : ObjectGraphType<Course>
    {
        public CourseType()
        {
            Name = "Course";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the course.");
            Field(x => x.Name).Description("The name of the course");
        }
    }
    
}