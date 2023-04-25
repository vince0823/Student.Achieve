using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Achieve.Infrastructure.Migrations
{
    public partial class changuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TargetId",
                table: "IdentityUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "IdentityUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetId",
                table: "IdentityUsers");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "IdentityUsers");
        }
    }
}
