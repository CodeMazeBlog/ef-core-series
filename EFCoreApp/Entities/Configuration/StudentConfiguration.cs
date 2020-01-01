using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.Property(s => s.Age)
                .IsRequired(false);
            builder.Property(s => s.IsRegularStudent)
                .HasDefaultValue(true);

            builder.HasData
            (
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    Age = 30
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "Jane Doe",
                    Age = 25
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "Mike Miles",
                    Age = 28
                }
            );
        }
    }
}
