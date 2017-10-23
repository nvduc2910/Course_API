using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Course_API.Migrations
{
    public partial class countryfortrainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Trainer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Trainer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_CityId",
                table: "Trainer",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_CountryId",
                table: "Trainer",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_City_CityId",
                table: "Trainer",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_Country_CountryId",
                table: "Trainer",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_City_CityId",
                table: "Trainer");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_Country_CountryId",
                table: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_Trainer_CityId",
                table: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_Trainer_CountryId",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Trainer");
        }
    }
}
