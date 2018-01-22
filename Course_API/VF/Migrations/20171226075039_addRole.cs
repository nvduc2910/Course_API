using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Course_API.Migrations
{
    public partial class addRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Trainee_TraineeId",
                table: "Favorite");

            migrationBuilder.DropIndex(
                name: "IX_Favorite_TraineeId",
                table: "Favorite");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reliance",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Favorite",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Trainee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_UserId",
                table: "Favorite",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Trainee_UserId",
                table: "Favorite",
                column: "UserId",
                principalTable: "Trainee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Trainee_UserId",
                table: "Favorite");

            migrationBuilder.DropIndex(
                name: "IX_Favorite_UserId",
                table: "Favorite");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reliance");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Favorite");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Trainee");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_TraineeId",
                table: "Favorite",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Trainee_TraineeId",
                table: "Favorite",
                column: "TraineeId",
                principalTable: "Trainee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
