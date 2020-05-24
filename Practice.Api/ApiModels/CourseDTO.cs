using Practice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Api.ApiModels
{
    public class CourseDTO
    {
        public int CourseID { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public static CourseDTO FromCourse(Course item)
        {
            return new CourseDTO()
            {
                CourseID = item.CourseID,
                Title = item.Title,
                Credits = item.Credits,
                DepartmentID = item.DepartmentID
            };
        }
    }
}
