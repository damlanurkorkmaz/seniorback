using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayer.Core.Models;
using NLayer.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext: IdentityDbContext<UserApp, IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<CanceledWatch> CanceledWatches { get; set; }
        public DbSet<PersonnelSeniority> PersonnelSeniorities { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }



        // entitiylerle ilgili ayarları yapabilmek için migration esnasında;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());//yukarıdaki kodun aynısı
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 200,
                ProductId = 1
            });

            modelBuilder.Entity<CanceledWatch>()
                .Property(cw => cw.CanceledWatchTime)
                .HasColumnType("datetimeoffset");

            modelBuilder.Entity<Watch>()
                .Property(cw => cw.WatchEndTime)
                .HasColumnType("datetimeoffset");

            modelBuilder.Entity<Watch>()
                .Property(cw => cw.WatchStartTime)
                .HasColumnType("datetimeoffset");




            base.OnModelCreating(modelBuilder); 
        }

    }
}
