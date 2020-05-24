using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Infrastructure.Data.Config
{
    public class CourseInstructorConfiguration : IEntityTypeConfiguration<CourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CourseInstructor> builder)
        {
            builder.HasKey(t => t.CourseID);
            builder.HasKey(t => t.InstructorID);
        }
    }
}
