using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Core.Entities
{
    public class Course
    {
        public int CourseID { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public int DepartmentID { get; set; }
    }
}
