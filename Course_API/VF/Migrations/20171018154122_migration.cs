using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Course_API.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_DisableType_DisableTypeId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "DisableTypeId",
                table: "User",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_User_DisableType_DisableTypeId",
                table: "User",
                column: "DisableTypeId",
                principalTable: "DisableType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_DisableType_DisableTypeId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "DisableTypeId",
                table: "User",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_DisableType_DisableTypeId",
                table: "User",
                column: "DisableTypeId",
                principalTable: "DisableType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
