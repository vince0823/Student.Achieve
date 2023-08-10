using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Achieve.Infrastructure.Migrations
{
    public partial class changeScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentScores_ExamTasks_ExamTaskId",
                table: "StudentScores");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentScores_Students_StudentId",
                table: "StudentScores");

            migrationBuilder.DropIndex(
                name: "IX_StudentScores_ExamTaskId",
                table: "StudentScores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentScores_ExamTaskId",
                table: "StudentScores",
                column: "ExamTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentScores_ExamTasks_ExamTaskId",
                table: "StudentScores",
                column: "ExamTaskId",
                principalTable: "ExamTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentScores_Students_StudentId",
                table: "StudentScores",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
