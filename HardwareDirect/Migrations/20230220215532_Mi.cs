using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareDirect.Migrations
{
    public partial class Mi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmplooyeesTasks_TaskStatus_TaskStatusId",
                table: "EmplooyeesTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStatus",
                table: "TaskStatus");

            migrationBuilder.RenameTable(
                name: "TaskStatus",
                newName: "TaskStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStatuses",
                table: "TaskStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmplooyeesTasks_TaskStatuses_TaskStatusId",
                table: "EmplooyeesTasks",
                column: "TaskStatusId",
                principalTable: "TaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmplooyeesTasks_TaskStatuses_TaskStatusId",
                table: "EmplooyeesTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStatuses",
                table: "TaskStatuses");

            migrationBuilder.RenameTable(
                name: "TaskStatuses",
                newName: "TaskStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStatus",
                table: "TaskStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmplooyeesTasks_TaskStatus_TaskStatusId",
                table: "EmplooyeesTasks",
                column: "TaskStatusId",
                principalTable: "TaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
