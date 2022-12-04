using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NicosiaAssingment.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PwdHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_AcademicPeriods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "AcademicPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ApproverId = table.Column<int>(type: "int", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Sections_TargetSectionId",
                        column: x => x.TargetSectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SectionLecturers",
                columns: table => new
                {
                    LecturedSectionId = table.Column<int>(type: "int", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionLecturers", x => new { x.LecturerId, x.LecturedSectionId });
                    table.ForeignKey(
                        name: "FK_SectionLecturers_Sections_LecturedSectionId",
                        column: x => x.LecturedSectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionLecturers_Users_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrollments",
                columns: table => new
                {
                    EnrolledInId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrollments", x => new { x.StudentId, x.EnrolledInId });
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Sections_EnrolledInId",
                        column: x => x.EnrolledInId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcademicPeriods",
                columns: new[] { "Id", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 6, 1, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "First semester 2022", new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2022, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Second semester 2022", new DateTimeOffset(new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[,]
                {
                    { 1, "Math-231", "Calculus" },
                    { 2, "IT-888", "Intoduction to Linux" },
                    { 3, "ENG-153", "An Introduction to Literary Analysis" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "InsuranceNumber", "LastName", "Phone", "PwdHash", "Role" },
                values: new object[,]
                {
                    { 1, "john-petrucci@nicosia.com", "John", null, "Petrucci", "+1 999 999 99 99", "18138372fad4b94533cd4881f03dc6c69296dd897234e0cee83f727e2e6b1f63", "Student" },
                    { 2, "max-well@nicosia.com", "Max", null, "Well", "+1 888 888 88 88", "54d5cb2d332dbdb4850293caae4559ce88b65163f1ea5d4e4b3ac49d772ded14", "Student" },
                    { 3, "brian-dough@nicosia.com", "Brian", null, "Dough", "+1 777 777 77 77", "0d81684688d4057da4d9f6df64b28154b68afc2f1946a756302613c92fdd4986", "Student" },
                    { 4, "satoshi-nakamoto@nicosia.com", "Satoshi", null, "Nakamoto", "+1 666 666 66 66", "1ec9baf4b0382c4a7eecb19c0d3dc53dd90964f38023fc273fb25829da7024d0", "Lecturer" },
                    { 5, "john-lock@nicosia.com", "John", null, "Lock", "+1 555 555 55 55", "95d8c859da2bf9c77e775a3e15221028863e13fc5280c6dc3b8c46d2ed32e13c", "Lecturer" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "PeriodId", "SectionNumber" },
                values: new object[] { 1, 1, 1, "Spring2022_1" });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "PeriodId", "SectionNumber" },
                values: new object[] { 2, 2, 1, "Summer2022_1" });

            migrationBuilder.InsertData(
                table: "SectionLecturers",
                columns: new[] { "LecturedSectionId", "LecturerId", "Id" },
                values: new object[,]
                {
                    { 2, 4, 1 },
                    { 1, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "StudentEnrollments",
                columns: new[] { "EnrolledInId", "StudentId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 3 },
                    { 1, 3, 4 },
                    { 2, 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ApproverId",
                table: "Messages",
                column: "ApproverId",
                unique: true,
                filter: "[ApproverId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TargetSectionId",
                table: "Messages",
                column: "TargetSectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionLecturers_LecturedSectionId",
                table: "SectionLecturers",
                column: "LecturedSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_PeriodId",
                table: "Sections",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_EnrolledInId",
                table: "StudentEnrollments",
                column: "EnrolledInId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "SectionLecturers");

            migrationBuilder.DropTable(
                name: "StudentEnrollments");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AcademicPeriods");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
