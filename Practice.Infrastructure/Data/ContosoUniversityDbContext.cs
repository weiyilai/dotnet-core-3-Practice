using Microsoft.EntityFrameworkCore;
using Practice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Infrastructure.Data
{
    public class ContosoUniversityDbContext : DbContext
    {
        public ContosoUniversityDbContext(DbContextOptions<ContosoUniversityDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        public DbSet<Person> People { get; set; }
    }
}
