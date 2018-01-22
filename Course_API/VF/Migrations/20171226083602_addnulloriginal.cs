using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Course_API.Migrations
{
    public partial class addnulloriginal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Organizer_OrganizerId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizerId",
                table: "Course",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Organizer_OrganizerId",
                table: "Course",
                column: "OrganizerId",
                principalTable: "Organizer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Organizer_OrganizerId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizerId",
                table: "Course",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Organizer_OrganizerId",
                table: "Course",
                column: "OrganizerId",
                principalTable: "Organizer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
