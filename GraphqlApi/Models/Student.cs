namespace GraphqlApi.Models
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public int Id {get; set;}

        public string Name {get; set;}   

        public ICollection<Course> Courses { get; set; }
    }
    
}