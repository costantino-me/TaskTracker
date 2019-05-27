using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.API.Migrations
{
    public partial class ClientTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClientTasks");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ClientTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClientTasks_UserId",
                table: "ClientTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTasks_AspNetUsers_UserId",
                table: "ClientTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientTasks_AspNetUsers_UserId",
                table: "ClientTasks");

            migrationBuilder.DropIndex(
                name: "IX_ClientTasks_UserId",
                table: "ClientTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ClientTasks");

            migrationBuilder.CreateTable(
                name: "UserClientTasks",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ClientTaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClientTasks", x => new { x.UserId, x.ClientTaskId });
                    table.ForeignKey(
                        name: "FK_UserClientTasks_ClientTasks_ClientTaskId",
                        column: x => x.ClientTaskId,
                        principalTable: "ClientTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClientTasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClientTasks_ClientTaskId",
                table: "UserClientTasks",
                column: "ClientTaskId");
        }
    }
}
