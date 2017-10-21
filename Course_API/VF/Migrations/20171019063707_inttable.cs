using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Course_API.Migrations
{
    public partial class inttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClaim_User_UserId",
                table: "UserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_User_UserId",
                table: "UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DisableType",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ActiveStatus",
                newName: "Status");

            migrationBuilder.CreateTable(
                name: "CourseCancelReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCancelReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseFlag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Flag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFlag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseScope",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Scope = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseScope", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelianceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelianceStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstitudeFlag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Flag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitudeFlag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstituteStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstituteType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizerStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizerStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    National = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainerFlag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Flag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerFlag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainerStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainerTitle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reliance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Logo = table.Column<string>(nullable: true),
                    RelianceStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reliance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reliance_RelianceStatus_RelianceStatusId",
                        column: x => x.RelianceStatusId,
                        principalTable: "RelianceStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Institute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    About = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    CommissionRate = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    FlagDate = table.Column<DateTime>(nullable: false),
                    GooglePlus = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    InstitudeFlagId = table.Column<int>(nullable: false),
                    InstituteTypeId = table.Column<int>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Snapchat = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    TelePhoneNumber = table.Column<string>(nullable: true),
                    Telegram = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    UNANumber = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institute_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Institute_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Institute_InstitudeFlag_InstitudeFlagId",
                        column: x => x.InstitudeFlagId,
                        principalTable: "InstitudeFlag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Institute_InstituteType_InstituteTypeId",
                        column: x => x.InstituteTypeId,
                        principalTable: "InstituteType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OrganizerStatusId = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizer_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizer_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizer_OrganizerStatus_OrganizerStatusId",
                        column: x => x.OrganizerStatusId,
                        principalTable: "OrganizerStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ActiveStatusId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    DeviceToken = table.Column<string>(nullable: true),
                    Disable = table.Column<bool>(nullable: false),
                    DisableTypeId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NationalityId = table.Column<int>(nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    PinCode = table.Column<int>(nullable: false),
                    PinCodeExpiration = table.Column<DateTime>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainee_ActiveStatus_ActiveStatusId",
                        column: x => x.ActiveStatusId,
                        principalTable: "ActiveStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainee_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainee_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainee_DisableType_DisableTypeId",
                        column: x => x.DisableTypeId,
                        principalTable: "DisableType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainee_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    About = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    FlagDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    GooglePlus = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Snapchat = table.Column<string>(nullable: true),
                    Telegram = table.Column<string>(nullable: true),
                    TrainerFlagId = table.Column<int>(nullable: false),
                    TrainerNationalityId = table.Column<int>(nullable: false),
                    TrainerStatusId = table.Column<int>(nullable: false),
                    TrainerTitleId = table.Column<int>(nullable: false),
                    Twitter = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainer_TrainerFlag_TrainerFlagId",
                        column: x => x.TrainerFlagId,
                        principalTable: "TrainerFlag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainer_Nationality_TrainerNationalityId",
                        column: x => x.TrainerNationalityId,
                        principalTable: "Nationality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainer_TrainerStatus_TrainerStatusId",
                        column: x => x.TrainerStatusId,
                        principalTable: "TrainerStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainer_TrainerTitle_TrainerTitleId",
                        column: x => x.TrainerTitleId,
                        principalTable: "TrainerTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    ContactNumberSecond = table.Column<string>(nullable: true),
                    ContactNumerFirst = table.Column<string>(nullable: true),
                    CourseCancelReasonId = table.Column<int>(nullable: false),
                    CourseCategoryId = table.Column<int>(nullable: false),
                    CourseFlagId = table.Column<int>(nullable: true),
                    CourseLanguageId = table.Column<int>(nullable: false),
                    CourseLevelId = table.Column<int>(nullable: false),
                    CourseScopeId = table.Column<int>(nullable: false),
                    CourseStatusId = table.Column<int>(nullable: false),
                    CourseTypeId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Disable = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<string>(nullable: true),
                    FlagDate = table.Column<DateTime>(nullable: false),
                    FlagId = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    GroupPrice = table.Column<int>(nullable: false),
                    HoursTotal = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    InstituteId = table.Column<int>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Long = table.Column<double>(nullable: false),
                    MainPrice = table.Column<int>(nullable: false),
                    MotivationDate = table.Column<DateTime>(nullable: false),
                    MotivationPrice = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OnlineLink = table.Column<string>(nullable: true),
                    OrganizerId = table.Column<int>(nullable: false),
                    Others = table.Column<string>(nullable: true),
                    PriceType = table.Column<int>(nullable: false),
                    PromotionDetails = table.Column<string>(nullable: true),
                    RegisterLink = table.Column<string>(nullable: true),
                    StarTime = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    Targerts = table.Column<string>(nullable: true),
                    VideoLink = table.Column<string>(nullable: true),
                    WhatAppsNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_CourseCancelReason_CourseCancelReasonId",
                        column: x => x.CourseCancelReasonId,
                        principalTable: "CourseCancelReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_CourseCategory_CourseCategoryId",
                        column: x => x.CourseCategoryId,
                        principalTable: "CourseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_CourseFlag_CourseFlagId",
                        column: x => x.CourseFlagId,
                        principalTable: "CourseFlag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_CourseLanguage_CourseLanguageId",
                        column: x => x.CourseLanguageId,
                        principalTable: "CourseLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_CourseLevel_CourseLevelId",
                        column: x => x.CourseLevelId,
                        principalTable: "CourseLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_CourseScope_CourseScopeId",
                        column: x => x.CourseScopeId,
                        principalTable: "CourseScope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_CourseStatus_CourseStatusId",
                        column: x => x.CourseStatusId,
                        principalTable: "CourseStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_CourseType_CourseTypeId",
                        column: x => x.CourseTypeId,
                        principalTable: "CourseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Organizer_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourRel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    RelianceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourRel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourRel_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourRel_Reliance_RelianceId",
                        column: x => x.RelianceId,
                        principalTable: "Reliance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourTra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    TrainerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourTra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourTra_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourTra_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseCancelReasonId",
                table: "Course",
                column: "CourseCancelReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseCategoryId",
                table: "Course",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseFlagId",
                table: "Course",
                column: "CourseFlagId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseLanguageId",
                table: "Course",
                column: "CourseLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseLevelId",
                table: "Course",
                column: "CourseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseScopeId",
                table: "Course",
                column: "CourseScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseStatusId",
                table: "Course",
                column: "CourseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseTypeId",
                table: "Course",
                column: "CourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CurrencyId",
                table: "Course",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_InstituteId",
                table: "Course",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_OrganizerId",
                table: "Course",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reliance_RelianceStatusId",
                table: "Reliance",
                column: "RelianceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CourRel_CourseId",
                table: "CourRel",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourRel_RelianceId",
                table: "CourRel",
                column: "RelianceId");

            migrationBuilder.CreateIndex(
                name: "IX_CourTra_CourseId",
                table: "CourTra",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourTra_TrainerId",
                table: "CourTra",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Institute_CityId",
                table: "Institute",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Institute_CountryId",
                table: "Institute",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Institute_InstitudeFlagId",
                table: "Institute",
                column: "InstitudeFlagId");

            migrationBuilder.CreateIndex(
                name: "IX_Institute_InstituteTypeId",
                table: "Institute",
                column: "InstituteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_CityId",
                table: "Organizer",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_CountryId",
                table: "Organizer",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_OrganizerStatusId",
                table: "Organizer",
                column: "OrganizerStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_ActiveStatusId",
                table: "Trainee",
                column: "ActiveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_CityId",
                table: "Trainee",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_CountryId",
                table: "Trainee",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_DisableTypeId",
                table: "Trainee",
                column: "DisableTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_NationalityId",
                table: "Trainee",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Trainee",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Trainee",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_TrainerFlagId",
                table: "Trainer",
                column: "TrainerFlagId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_TrainerNationalityId",
                table: "Trainer",
                column: "TrainerNationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_TrainerStatusId",
                table: "Trainer",
                column: "TrainerStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_TrainerTitleId",
                table: "Trainer",
                column: "TrainerTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaim_Trainee_UserId",
                table: "UserClaim",
                column: "UserId",
                principalTable: "Trainee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_Trainee_UserId",
                table: "UserLogin",
                column: "UserId",
                principalTable: "Trainee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Trainee_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "Trainee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClaim_Trainee_UserId",
                table: "UserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_Trainee_UserId",
                table: "UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Trainee_UserId",
                table: "UserRole");

            migrationBuilder.DropTable(
                name: "CourRel");

            migrationBuilder.DropTable(
                name: "CourTra");

            migrationBuilder.DropTable(
                name: "InstituteStatus");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Reliance");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "RelianceStatus");

            migrationBuilder.DropTable(
                name: "CourseCancelReason");

            migrationBuilder.DropTable(
                name: "CourseCategory");

            migrationBuilder.DropTable(
                name: "CourseFlag");

            migrationBuilder.DropTable(
                name: "CourseLanguage");

            migrationBuilder.DropTable(
                name: "CourseLevel");

            migrationBuilder.DropTable(
                name: "CourseScope");

            migrationBuilder.DropTable(
                name: "CourseStatus");

            migrationBuilder.DropTable(
                name: "CourseType");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Institute");

            migrationBuilder.DropTable(
                name: "Organizer");

            migrationBuilder.DropTable(
                name: "TrainerFlag");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropTable(
                name: "TrainerStatus");

            migrationBuilder.DropTable(
                name: "TrainerTitle");

            migrationBuilder.DropTable(
                name: "InstitudeFlag");

            migrationBuilder.DropTable(
                name: "InstituteType");

            migrationBuilder.DropTable(
                name: "OrganizerStatus");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "DisableType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ActiveStatus",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ActiveStatusId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    DeviceToken = table.Column<string>(nullable: true),
                    Disable = table.Column<bool>(nullable: false),
                    DisableTypeId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    PinCode = table.Column<int>(nullable: false),
                    PinCodeExpiration = table.Column<DateTime>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_ActiveStatus_ActiveStatusId",
                        column: x => x.ActiveStatusId,
                        principalTable: "ActiveStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_DisableType_DisableTypeId",
                        column: x => x.DisableTypeId,
                        principalTable: "DisableType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ActiveStatusId",
                table: "User",
                column: "ActiveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CityId",
                table: "User",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CountryId",
                table: "User",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DisableTypeId",
                table: "User",
                column: "DisableTypeId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaim_User_UserId",
                table: "UserClaim",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_User_UserId",
                table: "UserLogin",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
