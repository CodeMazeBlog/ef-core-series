using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
                    Id = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"),
                    Name = "John Doe",
                    Age = 30
                },
                new Student
                {
                    Id = new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac"),
                    Name = "Jane Doe",
                    Age = 25
                },
                new Student
                {
                    Id = new Guid("4addc421-0937-45cb-b55c-200b45c6caca"),
                    Name = "Mike Miles",
                    Age = 28
                }
            );

            builder.HasMany(e => e.Evaluations)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
