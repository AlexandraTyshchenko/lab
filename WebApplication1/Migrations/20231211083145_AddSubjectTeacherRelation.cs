using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddSubjectTeacherRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Groups_GroupId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_SubjectTeachers_SubjectTeacherId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeachers_Subjects_SubjectId",
                table: "SubjectTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeachers_Teachers_TeacherId",
                table: "SubjectTeachers");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Groups_GroupId",
                table: "Schedules",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_SubjectTeachers_SubjectTeacherId",
                table: "Schedules",
                column: "SubjectTeacherId",
                principalTable: "SubjectTeachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeachers_Subjects_SubjectId",
                table: "SubjectTeachers",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeachers_Teachers_TeacherId",
                table: "SubjectTeachers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Groups_GroupId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_SubjectTeachers_SubjectTeacherId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeachers_Subjects_SubjectId",
                table: "SubjectTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeachers_Teachers_TeacherId",
                table: "SubjectTeachers");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Groups_GroupId",
                table: "Schedules",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_SubjectTeachers_SubjectTeacherId",
                table: "Schedules",
                column: "SubjectTeacherId",
                principalTable: "SubjectTeachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeachers_Subjects_SubjectId",
                table: "SubjectTeachers",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeachers_Teachers_TeacherId",
                table: "SubjectTeachers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
