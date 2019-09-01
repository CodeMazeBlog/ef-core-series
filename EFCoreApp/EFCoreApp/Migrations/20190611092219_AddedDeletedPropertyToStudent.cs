using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreApp.Migrations
{
    public partial class AddedDeletedPropertyToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("6d662b0f-2ea3-452a-8051-2b9dc4bd03e8"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("a0423daf-c930-4d88-a33d-114b742e563e"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("bd74f429-5161-4761-ad11-7eb074aee323"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("ed2198fb-3b7b-4d9e-bda1-c35f53e2e5be"));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Student",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Evaluation",
                columns: new[] { "EvaluationId", "AdditionalExplanation", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("2182ea19-2a58-4195-b431-5bfea285d8fc"), "First test...", 5, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("60249811-7310-45b2-b5de-083e6028ffea"), "Second test...", 4, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("baa449fb-2466-47dd-809a-061e30c91b53"), "First test...", 3, new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac") },
                    { new Guid("2f2ec637-4601-4bec-b0b1-f42271368596"), "Last test...", 2, new Guid("4addc421-0937-45cb-b55c-200b45c6caca") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("2182ea19-2a58-4195-b431-5bfea285d8fc"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("2f2ec637-4601-4bec-b0b1-f42271368596"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("60249811-7310-45b2-b5de-083e6028ffea"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("baa449fb-2466-47dd-809a-061e30c91b53"));

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Student");

            migrationBuilder.InsertData(
                table: "Evaluation",
                columns: new[] { "EvaluationId", "AdditionalExplanation", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("a0423daf-c930-4d88-a33d-114b742e563e"), "First test...", 5, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("ed2198fb-3b7b-4d9e-bda1-c35f53e2e5be"), "Second test...", 4, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("bd74f429-5161-4761-ad11-7eb074aee323"), "First test...", 3, new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac") },
                    { new Guid("6d662b0f-2ea3-452a-8051-2b9dc4bd03e8"), "Last test...", 2, new Guid("4addc421-0937-45cb-b55c-200b45c6caca") }
                });
        }
    }
}
