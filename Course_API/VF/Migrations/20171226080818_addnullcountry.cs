using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Course_API.Migrations
{
    public partial class addnullcountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_City_CityId",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Country_CountryId",
                table: "Trainee");

            migrationBuilder.AlterColumn<int>(
                name: "PinCode",
                table: "Trainee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Trainee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Trainee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_City_CityId",
                table: "Trainee",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Country_CountryId",
                table: "Trainee",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_City_CityId",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Country_CountryId",
                table: "Trainee");

            migrationBuilder.AlterColumn<int>(
                name: "PinCode",
                table: "Trainee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Trainee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Trainee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_City_CityId",
                table: "Trainee",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Country_CountryId",
                table: "Trainee",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
