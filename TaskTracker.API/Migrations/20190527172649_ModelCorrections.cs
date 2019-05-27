using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.API.Migrations
{
    public partial class ModelCorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ClientTasks");

            migrationBuilder.RenameColumn(
                name: "KnownAs",
                table: "AspNetUsers",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "AspNetUsers",
                newName: "KnownAs");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ClientTasks",
                nullable: true);
        }
    }
}
