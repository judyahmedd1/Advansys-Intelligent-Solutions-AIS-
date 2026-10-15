using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace universitysytem.Migrations
{
    /// <inheritdoc />
    public partial class ContinueTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentID",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentID",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CoursesCourseID",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UniProgramsProgramID",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FK_Department",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    ClassroomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassroomBuilding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassroomCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.ClassroomID);
                });

            migrationBuilder.CreateTable(
                name: "CoursesPrerequisite",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    PrerequisiteCourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesPrerequisite", x => new { x.CourseID, x.PrerequisiteCourseID });
                    table.ForeignKey(
                        name: "FK_CoursesPrerequisite_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesPrerequisite_Courses_PrerequisiteCourseID",
                        column: x => x.PrerequisiteCourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UniPrograms",
                columns: table => new
                {
                    ProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    FK_Department = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniPrograms", x => x.ProgramID);
                });

            migrationBuilder.CreateTable(
                name: "CourseSections",
                columns: table => new
                {
                    CourseSectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseSectionSchedule = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseSectionCapacity = table.Column<short>(type: "smallint", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    SemesterID = table.Column<int>(type: "int", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    ClassroomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSections", x => x.CourseSectionID);
                    table.ForeignKey(
                        name: "FK_CourseSections_Classrooms_ClassroomID",
                        column: x => x.ClassroomID,
                        principalTable: "Classrooms",
                        principalColumn: "ClassroomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSections_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSections_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSections_Semesters_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semesters",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StudentAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StudentEnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentDOB = table.Column<DateTime>(type: "date", nullable: false),
                    ProgramID = table.Column<int>(type: "int", nullable: false),
                    AdvisorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Instructors_AdvisorID",
                        column: x => x.AdvisorID,
                        principalTable: "Instructors",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_UniPrograms_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "UniPrograms",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CourseSectionID = table.Column<int>(type: "int", nullable: false),
                    StudentEnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollments_CourseSections_CourseSectionID",
                        column: x => x.CourseSectionID,
                        principalTable: "CourseSections",
                        principalColumn: "CourseSectionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSections_Enrollments",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false),
                    CourseSectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSections_Enrollments", x => new { x.EnrollmentID, x.CourseSectionID });
                    table.ForeignKey(
                        name: "FK_CourseSections_Enrollments_CourseSections_CourseSectionID",
                        column: x => x.CourseSectionID,
                        principalTable: "CourseSections",
                        principalColumn: "CourseSectionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSections_Enrollments_Enrollments_EnrollmentID",
                        column: x => x.EnrollmentID,
                        principalTable: "Enrollments",
                        principalColumn: "EnrollmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students_Enrollments",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students_Enrollments", x => new { x.EnrollmentID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_Students_Enrollments_Enrollments_EnrollmentID",
                        column: x => x.EnrollmentID,
                        principalTable: "Enrollments",
                        principalColumn: "EnrollmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Enrollments_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CoursesCourseID",
                table: "Departments",
                column: "CoursesCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UniProgramsProgramID",
                table: "Departments",
                column: "UniProgramsProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_ClassroomID",
                table: "CourseSections",
                column: "ClassroomID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_CourseID",
                table: "CourseSections",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_InstructorID",
                table: "CourseSections",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_SemesterID",
                table: "CourseSections",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_Enrollments_CourseSectionID",
                table: "CourseSections_Enrollments",
                column: "CourseSectionID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesPrerequisite_PrerequisiteCourseID",
                table: "CoursesPrerequisite",
                column: "PrerequisiteCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseSectionID",
                table: "Enrollments",
                column: "CourseSectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentID",
                table: "Enrollments",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StudentID",
                table: "Payments",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AdvisorID",
                table: "Students",
                column: "AdvisorID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgramID",
                table: "Students",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentEmail",
                table: "Students",
                column: "StudentEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Enrollments_StudentID",
                table: "Students_Enrollments",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Courses_CoursesCourseID",
                table: "Departments",
                column: "CoursesCourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_UniPrograms_UniProgramsProgramID",
                table: "Departments",
                column: "UniProgramsProgramID",
                principalTable: "UniPrograms",
                principalColumn: "ProgramID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Courses_CoursesCourseID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_UniPrograms_UniProgramsProgramID",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "CourseSections_Enrollments");

            migrationBuilder.DropTable(
                name: "CoursesPrerequisite");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Students_Enrollments");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "CourseSections");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "UniPrograms");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CoursesCourseID",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_UniProgramsProgramID",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CoursesCourseID",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UniProgramsProgramID",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "FK_Department",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentID",
                table: "Courses",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentID",
                table: "Courses",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
