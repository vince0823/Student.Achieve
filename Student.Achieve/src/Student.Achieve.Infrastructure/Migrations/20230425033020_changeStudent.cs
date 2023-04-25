using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Achieve.Infrastructure.Migrations
{
    public partial class changeStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classs_Grades_GradeId1",
                table: "Classs");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classs_ClassId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Classs_GradeId1",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "ClassId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GradeId1",
                table: "Classs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClassId1",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GradeId1",
                table: "Classs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId1",
                table: "Students",
                column: "ClassId1");

            migrationBuilder.CreateIndex(
                name: "IX_Classs_GradeId1",
                table: "Classs",
                column: "GradeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Classs_Grades_GradeId1",
                table: "Classs",
                column: "GradeId1",
                principalTable: "Grades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classs_ClassId1",
                table: "Students",
                column: "ClassId1",
                principalTable: "Classs",
                principalColumn: "Id");
        }
    }
}
