using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareDirect.Migrations
{
    public partial class TaskStatusAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmplooyeesTasks_Employees_EmployeeId",
                table: "EmplooyeesTasks");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "EmplooyeesTasks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TaskDoneDate",
                table: "EmplooyeesTasks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmplooyeesTasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TaskStatusId",
                table: "EmplooyeesTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmplooyeesTasks_TaskStatusId",
                table: "EmplooyeesTasks",
                column: "TaskStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmplooyeesTasks_Employees_EmployeeId",
                table: "EmplooyeesTasks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmplooyeesTasks_TaskStatus_TaskStatusId",
                table: "EmplooyeesTasks",
                column: "TaskStatusId",
                principalTable: "TaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmplooyeesTasks_Employees_EmployeeId",
                table: "EmplooyeesTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_EmplooyeesTasks_TaskStatus_TaskStatusId",
                table: "EmplooyeesTasks");

            migrationBuilder.DropTable(
                name: "TaskStatus");

            migrationBuilder.DropIndex(
                name: "IX_EmplooyeesTasks_TaskStatusId",
                table: "EmplooyeesTasks");

            migrationBuilder.DropColumn(
                name: "TaskStatusId",
                table: "EmplooyeesTasks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TaskDoneDate",
                table: "EmplooyeesTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmplooyeesTasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "EmplooyeesTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_EmplooyeesTasks_Employees_EmployeeId",
                table: "EmplooyeesTasks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
