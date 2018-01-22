using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Course_API.Migrations
{
    public partial class addtrainerinsti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "Trainer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_InstituteId",
                table: "Trainer",
                column: "InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_Institute_InstituteId",
                table: "Trainer",
                column: "InstituteId",
                principalTable: "Institute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_Institute_InstituteId",
                table: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_Trainer_InstituteId",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "Trainer");
        }
    }
}
