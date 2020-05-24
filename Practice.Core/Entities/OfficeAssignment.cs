using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practice.Core.Entities
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }

        public string Location { get; set; }
    }
}
