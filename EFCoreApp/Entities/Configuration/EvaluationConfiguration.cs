using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasData
            (
                new Evaluation
                {
                    Id = Guid.NewGuid(),
                    Grade = 5,
                    AdditionalExplanation = "First test...",
                    StudentId = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a")
                },
                new Evaluation
                {
                    Id = Guid.NewGuid(),
                    Grade = 4,
                    AdditionalExplanation = "Second test...",
                    StudentId = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a")
                },
                new Evaluation
                {
                    Id = Guid.NewGuid(),
                    Grade = 3,
                    AdditionalExplanation = "First test...",
                    StudentId = new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac")
                },
                new Evaluation
                {
                    Id = Guid.NewGuid(),
                    Grade = 2,
                    AdditionalExplanation = "Last test...",
                    StudentId = new Guid("4addc421-0937-45cb-b55c-200b45c6caca")
                }
            );
        }
    }
}
