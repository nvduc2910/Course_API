using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Course_API.Migrations
{
    public partial class addRelience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectTime",
                table: "Favorite");

            migrationBuilder.RenameColumn(
                name: "InstituteId",
                table: "Favorite",
                newName: "PriceId");

            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "Reliance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseScopeId",
                table: "Favorite",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Favorite",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reliance_InstituteId",
                table: "Reliance",
                column: "InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reliance_Institute_InstituteId",
                table: "Reliance",
                column: "InstituteId",
                principalTable: "Institute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reliance_Institute_InstituteId",
                table: "Reliance");

            migrationBuilder.DropIndex(
                name: "IX_Reliance_InstituteId",
                table: "Reliance");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "Reliance");

            migrationBuilder.DropColumn(
                name: "CourseScopeId",
                table: "Favorite");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Favorite");

            migrationBuilder.RenameColumn(
                name: "PriceId",
                table: "Favorite",
                newName: "InstituteId");

            migrationBuilder.AddColumn<DateTime>(
                name: "SelectTime",
                table: "Favorite",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
