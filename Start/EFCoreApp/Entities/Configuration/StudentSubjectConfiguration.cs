using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasKey(s => new { s.StudentId, s.SubjectId });

            builder.HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);

            builder.HasOne(ss => ss.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);

            builder.HasData
            (
                new StudentSubject
                {
                    StudentId = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"),
                    SubjectId = new Guid("7e69e207-5131-4791-9064-57f6d3c47fc8")
                },
                new StudentSubject
                {
                    StudentId = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"),
                    SubjectId = new Guid("89fc9e5d-74f6-4d2e-ae82-76f2b1decce7")
                },
                new StudentSubject
                {
                    StudentId = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"),
                    SubjectId = new Guid("9e5f12c2-0aa2-49b0-9db2-7df40fecf9ad")
                },
                new StudentSubject
                {
                    StudentId = new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac"),
                    SubjectId = new Guid("fee204f4-a51d-44bb-a3d7-dcc2b5ee5d4f")
                },
                new StudentSubject
                {
                    StudentId = new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac"),
                    SubjectId = new Guid("7e69e207-5131-4791-9064-57f6d3c47fc8")
                },
                new StudentSubject
                {
                    StudentId = new Guid("4addc421-0937-45cb-b55c-200b45c6caca"),
                    SubjectId = new Guid("fee204f4-a51d-44bb-a3d7-dcc2b5ee5d4f")
                }
            );
        }
    }
}
