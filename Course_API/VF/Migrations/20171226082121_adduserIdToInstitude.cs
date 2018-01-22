using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Course_API.Migrations
{
    public partial class adduserIdToInstitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Institute",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Institute_UserId",
                table: "Institute",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Institute_Trainee_UserId",
                table: "Institute",
                column: "UserId",
                principalTable: "Trainee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institute_Trainee_UserId",
                table: "Institute");

            migrationBuilder.DropIndex(
                name: "IX_Institute_UserId",
                table: "Institute");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Institute");
        }
    }
}
