using Practice.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Infrastructure.Data
{
    public class CourseRepository : EfRepository, ICourseRepository
    {
        public CourseRepository(ContosoUniversityDbContext contosoUniversityDbContext) :
            base (contosoUniversityDbContext)
        { }
    }
}
