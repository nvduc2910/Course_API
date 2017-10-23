using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Course_API.Migrations
{
    public partial class favoritestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Trainer");

            migrationBuilder.CreateTable(
                name: "CourseFavorite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    TraineeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFavorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseFavorite_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseFavorite_Trainee_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainee",
                        principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseFavorite_CourseId",
                table: "CourseFavorite",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFavorite_TraineeId",
                table: "CourseFavorite",
                column: "TraineeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseFavorite");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Trainer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
