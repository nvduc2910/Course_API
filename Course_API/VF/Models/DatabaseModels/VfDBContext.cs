using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_API.Models.DatabaseModels.CourseModels;
using Course_API.Models.DatabaseModels.RelianceModels;
using Course_API.Models.DatabaseModels.RelModels;
using Course_API.Models.TrainerModels;
using Course_API.Models.DatabaseModels;

namespace Course_API.Models
{
    public class VfDbContext : IdentityDbContext<Trainee, IdentityRole<int>, int>
    {
        public VfDbContext(DbContextOptions<VfDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trainee>(entity =>
            {
                entity.ToTable("Trainee");

            });
            modelBuilder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRole");
            });
            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogin");
            });
            modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaim");
            });
            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserToken");
            });
            modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaim");
            });
        }


        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<DisableType> DisableType { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseCancelReason> CourseCancelReason { get; set; }
        public DbSet<CourseCategory> CourseCategory { get; set; }
        public DbSet<CourseFlag> CourseFlag { get; set; }
        public DbSet<CourseLanguage> CourseLanguage { get; set; }
        public DbSet<CourseLevel> CourseLevel { get; set; }
        public DbSet<CourseScope> CourseScope { get; set; }
        public DbSet<CourseStatus> CourseStatus { get; set; }
        public DbSet<CourseType> CourseType { get; set; }

        public DbSet<Institute> Institute { get; set; }
        public DbSet<InstitudeFlag> InstitudeFlag { get; set; }
        public DbSet<InstituteType> InstituteType { get; set; }
        public DbSet<InstituteStatus> InstituteStatus { get; set; }


        public DbSet<Organizer> Organizer { get; set; }
        public DbSet<OrganizerStatus> OrganizerStatus { get; set; }

        public DbSet<Reliance> Reliance { get; set; }
        public DbSet<RelianceStatus> RelianceStatus { get; set; }

        public DbSet<CourRel> CourRel { get; set; }
        public DbSet<CourTra> CourTra { get; set; }

        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<ActiveStatus> ActiveStatus { get; set; }


        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<TrainerFlag> TrainerFlag { get; set; }
        public DbSet<TrainerStatus> TrainerStatus { get; set; }
        public DbSet<TrainerTitle> TrainerTitle { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

    }
}
