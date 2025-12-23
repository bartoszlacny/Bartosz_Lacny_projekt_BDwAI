using Bartosz_Lacny_projekt_bazy_danych.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bartosz_Lacny_projekt_bazy_danych.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<AdoptionApplication> AdoptionApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Pies" },
                new Category { Id = 2, Name = "Kot" }
            );

            builder.Entity<Cage>().HasData(
                new Cage { Id = 1, CageNumber = "A-1", IsClean = true },
                new Cage { Id = 2, CageNumber = "B-2", IsClean = false }
            );
        }
    }
}