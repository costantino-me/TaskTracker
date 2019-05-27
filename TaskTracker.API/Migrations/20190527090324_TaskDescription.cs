using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.API.Migrations
{
    public partial class TaskDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ClientTasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "ClientTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "ClientTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ClientTasks");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "ClientTasks");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "ClientTasks");
        }
    }
}
