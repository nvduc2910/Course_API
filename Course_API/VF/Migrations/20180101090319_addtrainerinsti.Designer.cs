using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Course_API.Models;
using Course_API.Enums;

namespace Course_API.Migrations
{
    [DbContext(typeof(VfDbContext))]
    [Migration("20180101090319_addtrainerinsti")]
    partial class addtrainerinsti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Course_API.Models.ActiveStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("ActiveStatus");
                });

            modelBuilder.Entity("Course_API.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Course_API.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Course_API.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Age");

                    b.Property<string>("ContactNumberSecond");

                    b.Property<string>("ContactNumerFirst");

                    b.Property<int>("CourseCancelReasonId");

                    b.Property<int>("CourseCategoryId");

                    b.Property<int?>("CourseFlagId");

                    b.Property<int>("CourseLanguageId");

                    b.Property<int>("CourseLevelId");

                    b.Property<int>("CourseScopeId");

                    b.Property<int>("CourseStatusId");

                    b.Property<int>("CourseTypeId");

                    b.Property<int>("CurrencyId");

                    b.Property<int?>("DayTypeId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("Disable");

                    b.Property<string>("Email");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("EndTime");

                    b.Property<DateTime>("FlagDate");

                    b.Property<int>("FlagId");

                    b.Property<int>("Gender");

                    b.Property<int>("GroupPrice");

                    b.Property<int>("HoursTotal");

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<int>("InstituteId");

                    b.Property<bool>("IsApproved");

                    b.Property<double>("Lat");

                    b.Property<double>("Long");

                    b.Property<int>("MainPrice");

                    b.Property<DateTime>("MotivationDate");

                    b.Property<int>("MotivationPrice");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("OnlineLink");

                    b.Property<int?>("OrganizerId");

                    b.Property<string>("Others");

                    b.Property<int>("PriceType");

                    b.Property<string>("PromotionDetails");

                    b.Property<string>("RegisterLink");

                    b.Property<string>("StarTime");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Targerts");

                    b.Property<int>("TotalDay");

                    b.Property<string>("VideoLink");

                    b.Property<string>("WhatAppsNumber");

                    b.HasKey("Id");

                    b.HasIndex("CourseCancelReasonId");

                    b.HasIndex("CourseCategoryId");

                    b.HasIndex("CourseFlagId");

                    b.HasIndex("CourseLanguageId");

                    b.HasIndex("CourseLevelId");

                    b.HasIndex("CourseScopeId");

                    b.HasIndex("CourseStatusId");

                    b.HasIndex("CourseTypeId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("DayTypeId");

                    b.HasIndex("InstituteId");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Course_API.Models.CourseCancelReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Reason");

                    b.HasKey("Id");

                    b.ToTable("CourseCancelReason");
                });

            modelBuilder.Entity("Course_API.Models.CourseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.HasKey("Id");

                    b.ToTable("CourseCategory");
                });

            modelBuilder.Entity("Course_API.Models.CourseFlag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Flag");

                    b.HasKey("Id");

                    b.ToTable("CourseFlag");
                });

            modelBuilder.Entity("Course_API.Models.CourseLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Language");

                    b.HasKey("Id");

                    b.ToTable("CourseLanguage");
                });

            modelBuilder.Entity("Course_API.Models.CourseLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Level");

                    b.HasKey("Id");

                    b.ToTable("CourseLevel");
                });

            modelBuilder.Entity("Course_API.Models.CourseStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("CourseStatus");
                });

            modelBuilder.Entity("Course_API.Models.CourseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("CourseType");
                });

            modelBuilder.Entity("Course_API.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrencyCode");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.ContactUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<string>("ApplicationName");

                    b.Property<string>("CompanyName");

                    b.Property<string>("ContactNumber");

                    b.Property<string>("Email");

                    b.Property<string>("Facebook");

                    b.Property<string>("GooglePlus");

                    b.Property<string>("Instagram");

                    b.Property<string>("Remark");

                    b.Property<string>("Snapchat");

                    b.Property<string>("Telegram");

                    b.Property<string>("Twitter");

                    b.Property<string>("Website");

                    b.Property<string>("Welcome");

                    b.Property<string>("Youtube");

                    b.HasKey("Id");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.CourseModels.CourseScope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Scope");

                    b.HasKey("Id");

                    b.ToTable("CourseScope");
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.DayType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DayType");
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CityId");

                    b.Property<int>("CountryId");

                    b.Property<int?>("CourseId");

                    b.Property<int>("CourseScopeId");

                    b.Property<int>("CourseTypeId");

                    b.Property<int>("Gender");

                    b.Property<int>("PriceId");

                    b.Property<int>("TraineeId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.RelianceModels.Reliance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InstituteId");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.Property<int>("RelianceStatusId");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.HasIndex("RelianceStatusId");

                    b.ToTable("Reliance");
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.RelianceModels.RelianceStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("RelianceStatus");
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.RelModels.CourRel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<int>("RelianceId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("RelianceId");

                    b.ToTable("CourRel");
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.RelModels.CourseDayType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<int>("DayTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("DayTypeId");

                    b.ToTable("CourseDayType");
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.RelModels.CourTra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<int>("TrainerId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TrainerId");

                    b.ToTable("CourTra");
                });

            modelBuilder.Entity("Course_API.Models.DisableType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("DisableType");
                });

            modelBuilder.Entity("Course_API.Models.InstitudeFlag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Flag");

                    b.HasKey("Id");

                    b.ToTable("InstitudeFlag");
                });

            modelBuilder.Entity("Course_API.Models.Institute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<string>("Address");

                    b.Property<int>("CityId");

                    b.Property<int>("CommissionRate");

                    b.Property<int>("CountryId");

                    b.Property<string>("Email");

                    b.Property<string>("Facebook");

                    b.Property<DateTime>("FlagDate");

                    b.Property<string>("GooglePlus");

                    b.Property<string>("Instagram");

                    b.Property<int>("InstitudeFlagId");

                    b.Property<int>("InstituteTypeId");

                    b.Property<double>("Lat");

                    b.Property<double>("Lng");

                    b.Property<string>("Logo");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Name");

                    b.Property<string>("Remark");

                    b.Property<string>("Snapchat");

                    b.Property<int>("StatusId");

                    b.Property<string>("TelePhoneNumber");

                    b.Property<string>("Telegram");

                    b.Property<string>("Twitter");

                    b.Property<string>("UNANumber");

                    b.Property<int?>("UserId");

                    b.Property<string>("Website");

                    b.Property<string>("Youtube");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("InstitudeFlagId");

                    b.HasIndex("InstituteTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Institute");
                });

            modelBuilder.Entity("Course_API.Models.InstituteStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("InstituteStatus");
                });

            modelBuilder.Entity("Course_API.Models.InstituteType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("InstituteType");
                });

            modelBuilder.Entity("Course_API.Models.Organizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("CityId");

                    b.Property<string>("ContactNumber");

                    b.Property<int>("CountryId");

                    b.Property<double>("Lat");

                    b.Property<double>("Lng");

                    b.Property<string>("Name");

                    b.Property<int>("OrganizerStatusId");

                    b.Property<string>("Remark");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("OrganizerStatusId");

                    b.ToTable("Organizer");
                });

            modelBuilder.Entity("Course_API.Models.OrganizerStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("OrganizerStatus");
                });

            modelBuilder.Entity("Course_API.Models.TrainerModels.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("National");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Nationality");
                });

            modelBuilder.Entity("Course_API.Models.TrainerModels.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<string>("Address");

                    b.Property<int?>("CityId");

                    b.Property<string>("ContactNumber");

                    b.Property<int?>("CountryId");

                    b.Property<string>("Email");

                    b.Property<string>("Facebook");

                    b.Property<DateTime>("FlagDate");

                    b.Property<int>("Gender");

                    b.Property<string>("GooglePlus");

                    b.Property<string>("Instagram");

                    b.Property<int>("InstituteId");

                    b.Property<double>("Lat");

                    b.Property<double>("Lng");

                    b.Property<string>("Logo");

                    b.Property<string>("Major");

                    b.Property<string>("Name");

                    b.Property<string>("Remark");

                    b.Property<string>("Snapchat");

                    b.Property<string>("Telegram");

                    b.Property<int>("TrainerFlagId");

                    b.Property<int>("TrainerNationalityId");

                    b.Property<int>("TrainerStatusId");

                    b.Property<int>("TrainerTitleId");

                    b.Property<string>("Twitter");

                    b.Property<string>("Website");

                    b.Property<string>("Youtube");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("InstituteId");

                    b.HasIndex("TrainerFlagId");

                    b.HasIndex("TrainerNationalityId");

                    b.HasIndex("TrainerStatusId");

                    b.HasIndex("TrainerTitleId");

                    b.ToTable("Trainer");
                });

            modelBuilder.Entity("Course_API.Models.TrainerModels.TrainerFlag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Flag");

                    b.HasKey("Id");

                    b.ToTable("TrainerFlag");
                });

            modelBuilder.Entity("Course_API.Models.TrainerModels.TrainerStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("TrainerStatus");
                });

            modelBuilder.Entity("Course_API.Models.TrainerModels.TrainerTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Status");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("TrainerTitle");
                });

            modelBuilder.Entity("Course_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("ActiveStatusId");

                    b.Property<int>("Age");

                    b.Property<int?>("CityId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("ContactNumber");

                    b.Property<int?>("CountryId");

                    b.Property<string>("DeviceToken");

                    b.Property<bool>("Disable");

                    b.Property<int?>("DisableTypeId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Gender");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<int?>("NationalityId");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int?>("PinCode");

                    b.Property<DateTime?>("PinCodeExpiration");

                    b.Property<int>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("ActiveStatusId");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("DisableTypeId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Trainee");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("Course_API.Models.City", b =>
                {
                    b.HasOne("Course_API.Models.Country", "Country")
                        .WithMany("City")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Course_API.Models.Course", b =>
                {
                    b.HasOne("Course_API.Models.CourseCancelReason", "CourseCancelReason")
                        .WithMany()
                        .HasForeignKey("CourseCancelReasonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.CourseCategory", "CourseCategory")
                        .WithMany()
                        .HasForeignKey("CourseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.CourseFlag", "CourseFlag")
                        .WithMany()
                        .HasForeignKey("CourseFlagId");

                    b.HasOne("Course_API.Models.CourseLanguage", "CourseLanguage")
                        .WithMany()
                        .HasForeignKey("CourseLanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.CourseLevel", "CourseLevel")
                        .WithMany()
                        .HasForeignKey("CourseLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.DatabaseModels.CourseModels.CourseScope", "CourseScope")
                        .WithMany()
                        .HasForeignKey("CourseScopeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.CourseStatus", "CourseStatus")
                        .WithMany()
                        .HasForeignKey("CourseStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.CourseType", "CourseType")
                        .WithMany()
                        .HasForeignKey("CourseTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.DatabaseModels.DayType")
                        .WithMany("Course")
                        .HasForeignKey("DayTypeId");

                    b.HasOne("Course_API.Models.Institute", "Institude")
                        .WithMany("Course")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.Organizer", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId");
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.Favorite", b =>
                {
                    b.HasOne("Course_API.Models.Course")
                        .WithMany("CourseFavorite")
                        .HasForeignKey("CourseId");

                    b.HasOne("Course_API.Models.User")
                        .WithMany("CourseFavorite")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.RelianceModels.Reliance", b =>
                {
                    b.HasOne("Course_API.Models.Institute", "Institute")
                        .WithMany("Reliance")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.DatabaseModels.RelianceModels.RelianceStatus", "RelianceStatus")
                        .WithMany()
                        .HasForeignKey("RelianceStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.RelModels.CourRel", b =>
                {
                    b.HasOne("Course_API.Models.Course", "Course")
                        .WithMany("CourRel")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.DatabaseModels.RelianceModels.Reliance", "Reliance")
                        .WithMany()
                        .HasForeignKey("RelianceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.RelModels.CourseDayType", b =>
                {
                    b.HasOne("Course_API.Models.Course", "Course")
                        .WithMany("CourseDayType")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.DatabaseModels.DayType", "DayType")
                        .WithMany()
                        .HasForeignKey("DayTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Course_API.Models.DatabaseModels.RelModels.CourTra", b =>
                {
                    b.HasOne("Course_API.Models.Course", "Course")
                        .WithMany("CourTra")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.TrainerModels.Trainer", "Trainer")
                        .WithMany("CourTra")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Course_API.Models.Institute", b =>
                {
                    b.HasOne("Course_API.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.InstitudeFlag", "InstitudeFlag")
                        .WithMany()
                        .HasForeignKey("InstitudeFlagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.InstituteType", "InstituteType")
                        .WithMany()
                        .HasForeignKey("InstituteTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Course_API.Models.Organizer", b =>
                {
                    b.HasOne("Course_API.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.OrganizerStatus", "OrganizerStatus")
                        .WithMany()
                        .HasForeignKey("OrganizerStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Course_API.Models.TrainerModels.Trainer", b =>
                {
                    b.HasOne("Course_API.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Course_API.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Course_API.Models.Institute", "Institute")
                        .WithMany("Trainer")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.TrainerModels.TrainerFlag", "TrainerFlag")
                        .WithMany()
                        .HasForeignKey("TrainerFlagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.TrainerModels.Nationality", "TrainerNationality")
                        .WithMany()
                        .HasForeignKey("TrainerNationalityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.TrainerModels.TrainerStatus", "TrainerStatus")
                        .WithMany()
                        .HasForeignKey("TrainerStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.TrainerModels.TrainerTitle", "TrainerTitle")
                        .WithMany()
                        .HasForeignKey("TrainerTitleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Course_API.Models.User", b =>
                {
                    b.HasOne("Course_API.Models.ActiveStatus", "ActiveStatus")
                        .WithMany()
                        .HasForeignKey("ActiveStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Course_API.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Course_API.Models.DisableType", "DisableType")
                        .WithMany()
                        .HasForeignKey("DisableTypeId");

                    b.HasOne("Course_API.Models.TrainerModels.Nationality", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<int>")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Course_API.Models.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Course_API.Models.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<int>")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Course_API.Models.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
