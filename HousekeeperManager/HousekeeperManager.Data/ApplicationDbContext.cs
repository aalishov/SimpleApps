using HousekeeperManager.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousekeeperManager.Data
{
    //Add-Migration InitialMigration -OutputDir "Data/Migrations"
    //Update-Database
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Housekeeper> Housekeepers { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Mission> Missions { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            //One-to-One Relationship
            builder.Entity<ApplicationUser>()
                .HasOne<Client>(c => c.Client)
                .WithOne(a => a.ApplicationUser)
                .HasForeignKey<Client>(s => s.ApplicationUserId);

            //One-to-One Relationship
            builder.Entity<ApplicationUser>()
                .HasOne<Housekeeper>(h => h.Housekeeper)
                .WithOne(a => a.ApplicationUser)
                .HasForeignKey<Housekeeper>(s => s.ApplicationUserId);
        }
    }
}