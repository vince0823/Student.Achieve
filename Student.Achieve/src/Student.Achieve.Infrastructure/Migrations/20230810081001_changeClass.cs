using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Achieve.Infrastructure.Migrations
{
    public partial class changeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classs_Grades_GradeId1",
                table: "Classs");

            migrationBuilder.DropIndex(
                name: "IX_Classs_GradeId1",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "GradeId1",
                table: "Classs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GradeId1",
                table: "Classs",
                type: "uniqueidentifier",
                nullable: true);

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
        }
    }
}
