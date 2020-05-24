using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Practice.Core.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        public int InstructorID { get; set; }

        public Byte[] RowVersion { get; set; }
    }
}
