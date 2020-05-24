using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Core.Entities
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int CourseID { get; set; }

        public int StudentID { get; set; }

        public int Grade { get; set; }
    }
}
