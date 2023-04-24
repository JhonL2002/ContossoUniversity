using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoUniversity.Migrations
{
    /// <inheritdoc />
    public partial class RecreateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_CourseId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_StudentId",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "Enrollments");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_CourseId",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Course",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "EnrollmentId");

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseInstructor",
                columns: table => new
                {
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false),
                    InstructorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstructor", x => new { x.CoursesCourseId, x.InstructorsId });
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Course_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Instructor_InstructorsId",
                        column: x => x.InstructorsId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfficeAssignments",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAssignments", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_OfficeAssignments_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_InstructorsId",
                table: "CourseInstructor",
                column: "InstructorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InstructorID",
                table: "Departments",
                column: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Departments_DepartmentId",
                table: "Course",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Course_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Student_StudentId",
                table: "Enrollments",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Departments_DepartmentId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Course_CourseId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Student_StudentId",
                table: "Enrollments");

            migrationBuilder.DropTable(
                name: "CourseInstructor");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "OfficeAssignments");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_Course_DepartmentId",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "Enrollment");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollment",
                newName: "IX_Enrollment_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "EnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_CourseId",
                table: "Enrollment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_StudentId",
                table: "Enrollment",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
