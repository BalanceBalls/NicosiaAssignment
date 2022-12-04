using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NicosiaAssingment.DataAccess.Migrations
{
    public partial class AddMoreSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[] { 4, "ART-991", "An Introduction to painting" });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "PeriodId", "SectionNumber" },
                values: new object[] { 4, 3, 2, "Fall2022_2" });

            migrationBuilder.InsertData(
                table: "SectionLecturers",
                columns: new[] { "LecturedSectionId", "LecturerId", "Id" },
                values: new object[] { 4, 5, 4 });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "PeriodId", "SectionNumber" },
                values: new object[] { 3, 4, 2, "Fall2022_1" });

            migrationBuilder.InsertData(
                table: "StudentEnrollments",
                columns: new[] { "EnrolledInId", "StudentId", "Id" },
                values: new object[,]
                {
                    { 4, 2, 6 },
                    { 4, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "SectionLecturers",
                columns: new[] { "LecturedSectionId", "LecturerId", "Id" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.InsertData(
                table: "StudentEnrollments",
                columns: new[] { "EnrolledInId", "StudentId", "Id" },
                values: new object[] { 3, 1, 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SectionLecturers",
                keyColumns: new[] { "LecturedSectionId", "LecturerId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "SectionLecturers",
                keyColumns: new[] { "LecturedSectionId", "LecturerId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "StudentEnrollments",
                keyColumns: new[] { "EnrolledInId", "StudentId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "StudentEnrollments",
                keyColumns: new[] { "EnrolledInId", "StudentId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "StudentEnrollments",
                keyColumns: new[] { "EnrolledInId", "StudentId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
