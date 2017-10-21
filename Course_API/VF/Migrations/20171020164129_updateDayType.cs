using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Course_API.Migrations
{
    public partial class updateDayType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayTypeId",
                table: "Course",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DayType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseDayType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    DayTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDayType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDayType_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDayType_DayType_DayTypeId",
                        column: x => x.DayTypeId,
                        principalTable: "DayType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DayTypeId",
                table: "Course",
                column: "DayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDayType_CourseId",
                table: "CourseDayType",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDayType_DayTypeId",
                table: "CourseDayType",
                column: "DayTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_DayType_DayTypeId",
                table: "Course",
                column: "DayTypeId",
                principalTable: "DayType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_DayType_DayTypeId",
                table: "Course");

            migrationBuilder.DropTable(
                name: "CourseDayType");

            migrationBuilder.DropTable(
                name: "DayType");

            migrationBuilder.DropIndex(
                name: "IX_Course_DayTypeId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "DayTypeId",
                table: "Course");
        }
    }
}
