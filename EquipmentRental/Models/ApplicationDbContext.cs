using EquipmentRental.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EquipmentRental.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().HasData(new List<Equipment>
            {
                new Equipment{Id=1,Name="Caterpillar bulldozer",Type_id=3},
                new Equipment{Id=2,Name="KamAZ truck",Type_id=2},
                new Equipment{Id=3,Name="Komatsu crane",Type_id=3},
                new Equipment{Id=4,Name="Volvo steamroller",Type_id=2},
                new Equipment{Id=5,Name="Bosch jackhammer",Type_id=1}
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
