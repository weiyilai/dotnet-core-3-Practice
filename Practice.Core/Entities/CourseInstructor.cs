using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practice.Core.Entities
{
    public class CourseInstructor
    {
        [Key]
        public int CourseID { get; set; }

        public int InstructorID { get; set; }
    }
}
