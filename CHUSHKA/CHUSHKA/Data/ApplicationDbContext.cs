using CHUSHKA.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Type = CHUSHKA.Data.Models.Type;

namespace CHUSHKA.Data
{
    //Add-Migration 001 -OutputDir "Data/Migrations"
    //Update-Database
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Type> Types { get; set; }

        public virtual DbSet<Product> Products { get; set; }
    }
}
