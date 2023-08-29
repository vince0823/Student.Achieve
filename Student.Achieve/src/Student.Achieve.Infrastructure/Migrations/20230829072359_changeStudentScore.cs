﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Achieve.Infrastructure.Migrations
{
    public partial class changeStudentScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "StudentScores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentScores");
        }
    }
}
