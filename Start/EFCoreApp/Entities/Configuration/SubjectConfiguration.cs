using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasData
            (
                new Subject
                {
                    Id = new Guid("7e69e207-5131-4791-9064-57f6d3c47fc8"),
                    SubjectName = "Math"
                },
                new Subject
                {
                    Id = new Guid("89fc9e5d-74f6-4d2e-ae82-76f2b1decce7"),
                    SubjectName = "English"
                },
                new Subject
                {
                    Id = new Guid("9e5f12c2-0aa2-49b0-9db2-7df40fecf9ad"),
                    SubjectName = "History"
                },
                new Subject
                {
                    Id = new Guid("fee204f4-a51d-44bb-a3d7-dcc2b5ee5d4f"),
                    SubjectName = "Computer Science"
                }
            );
        }
    }
}
