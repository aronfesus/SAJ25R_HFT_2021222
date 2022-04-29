using Microsoft.EntityFrameworkCore;
using SAJ25R_HFT_2021222.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Repository.DbContextFolder
{
    public class GunDbContext : DbContext
    {

        public GunDbContext()
        {
            try
            {
                this.Database.EnsureCreated();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }

        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Retailer> Retailers { get; set; }
        public virtual DbSet<Gun> Guns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               .UseLazyLoadingProxies()
               .UseInMemoryDatabase("gundb");
            }


        }

        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Retailer retailer1 = new Retailer() { SellerId = 11, Salary = 3000, Name = "Dylan Lorraine", DeskId = 1, Position = "Boss", SellingDate = DateTime.Parse("2001.01.01.") };
            Retailer retailer2 = new Retailer() { SellerId = 12, Salary = 2600, Name = "Dom Osborn", DeskId = 2, Position = "ViceBoss", SellingDate = DateTime.Parse("2000.01.02.") };
            Retailer retailer3 = new Retailer() { SellerId = 13, Salary = 2400, Name = "Lalia Briscoe", DeskId = 3, Position = "Cashier", SellingDate = DateTime.Parse("2003.01.03.") };
            Retailer retailer4 = new Retailer() { SellerId = 14, Salary = 1800, Name = "Louella Faron", DeskId = 4, Position = "Seller", SellingDate = DateTime.Parse("2000.01.04.") };
            Retailer retailer5 = new Retailer() { SellerId = 15, Salary = 1500, Name = "Tim Dianne", DeskId = 5, Position = "Seller", SellingDate = DateTime.Parse("2005.01.05.") };

            Owner owner1 = new Owner() { OwnerId = 1, SellerId = 11, Age = 25, Name = "Ashleigh Happy", Job = "Butcher", Address = "Alabama 35217" };
            Owner owner2 = new Owner() { OwnerId = 2, SellerId = 12, Age = 52, Name = "Eliana Jacqueline", Job = "Gardener", Address = "California 35205" };
            Owner owner3 = new Owner() { OwnerId = 3, SellerId = 13, Age = 34, Name = "Esmond Meredith", Job = "Baker", Address = "New York 35226" };
            Owner owner4 = new Owner() { OwnerId = 4, SellerId = 14, Age = 56, Name = "Avery Daxton", Job = "Manager", Address = "Alabama 35287" };
            Owner owner5 = new Owner() { OwnerId = 5, SellerId = 15, Age = 41, Name = "Mildred Bevis", Job = "Plumer", Address = "Ohio 35217" };
            Owner owner6 = new Owner() { OwnerId = 6, SellerId = 11, Age = 52, Name = "Milton Lake", Job = "Architect", Address = "California 35205" };
            Owner owner7 = new Owner() { OwnerId = 7, SellerId = 12, Age = 66, Name = "Jarred Milani", Job = null, Address = "Alabama 35298" };
            Owner owner8 = new Owner() { OwnerId = 8, SellerId = 13, Age = 39, Name = "Theodore Xavior", Job = "Uber driver", Address = "Alabama 35211" };
            Owner owner9 = new Owner() { OwnerId = 9, SellerId = 14, Age = 39, Name = "Venetia Felicity", Job = "Waiter", Address = "Alabama 35260" };
            Owner owner10 = new Owner() { OwnerId = 10, SellerId = 15, Age = 27, Name = "Georgiana Bill", Job = "Teacher", Address = "Alabama 35217" };

            Gun gun1 = new Gun() { SerialNumber = 987654, OwnerId = 1, GunName = "Glock", Caliber = "308 ACP", Weight = 3, Price = 450 };
            Gun gun2 = new Gun() { SerialNumber = 128537, OwnerId = 2, GunName = "M4", Caliber = "5.56 NATO", Weight = 9, Price = 3000 };
            Gun gun3 = new Gun() { SerialNumber = 492649, OwnerId = 3, GunName = "M4A1", Caliber = ".56 NATO", Weight = 9, Price = 3500 };
            Gun gun4 = new Gun() { SerialNumber = 992345, OwnerId = 4, GunName = "Colt", Caliber = "45 ACP", Weight = 4, Price = 600 };
            Gun gun5 = new Gun() { SerialNumber = 529574, OwnerId = 5, GunName = "Glock", Caliber = "308 ACP", Weight = 3, Price = 450 };
            Gun gun6 = new Gun() { SerialNumber = 239745, OwnerId = 6, GunName = "MP5", Caliber = "7.62 NATO", Weight = 6, Price = 2500 };
            Gun gun7 = new Gun() { SerialNumber = 395986, OwnerId = 7, GunName = "AK47", Caliber = "7.62 U", Weight = 10, Price = 2800 };
            Gun gun8 = new Gun() { SerialNumber = 678345, OwnerId = 8, GunName = "Glock", Caliber = "308 ACP", Weight = 3, Price = 450 };
            Gun gun9 = new Gun() { SerialNumber = 742745, OwnerId = 9, GunName = "UMP", Caliber = ".45 ACP", Weight = 7, Price = 2600 };
            Gun gun10 = new Gun() { SerialNumber = 893454, OwnerId = 10, GunName = "Desert Eagle", Caliber = ".44 Magnum", Weight = 5, Price = 1200 };
            Gun gun11 = new Gun() { SerialNumber = 999999, OwnerId = 1, GunName = "Magnum", Caliber = ".44 Magnum", Weight = 4, Price = 1000 };
            Gun gun12 = new Gun() { SerialNumber = 888888, OwnerId = 2, GunName = "UMP", Caliber = ".45 ACP", Weight = 7, Price = 2600 };
            Gun gun13 = new Gun() { SerialNumber = 777777, OwnerId = 3, GunName = "Beretta", Caliber = "223 REM", Weight = 2, Price = 300 };
            Gun gun14 = new Gun() { SerialNumber = 666666, OwnerId = 4, GunName = "M1 Garand", Caliber = ".30 Caliber", Weight = 5, Price = 1600 };
            Gun gun15 = new Gun() { SerialNumber = 555555, OwnerId = 5, GunName = "UZI", Caliber = ".45 ACP", Weight = 4, Price = 730 };
            Gun gun16 = new Gun() { SerialNumber = 444444, OwnerId = 6, GunName = "UZI", Caliber = ".45 ACP", Weight = 4, Price = 730 };
            Gun gun17 = new Gun() { SerialNumber = 333333, OwnerId = 7, GunName = "M1 Garand", Caliber = ".30 Caliber", Weight = 5, Price = 1600 };

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasOne(own => own.Retailer)
                .WithMany(r => r.Owners)
                .HasForeignKey(own => own.SellerId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Gun>(entity =>
            {
                entity.HasOne(g => g.Owner)
                .WithMany(o => o.Guns)
                .HasForeignKey(g => g.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Retailer>().HasData(retailer1, retailer2, retailer3, retailer4, retailer5);
            modelBuilder.Entity<Owner>().HasData(owner1, owner2, owner3, owner4, owner5, owner6, owner7, owner8, owner9, owner10);
            modelBuilder.Entity<Gun>().HasData(gun1, gun2, gun3, gun4, gun5, gun6, gun7, gun8, gun9, gun10, gun11, gun12, gun13, gun14, gun15, gun16, gun17);
        }


    }
}
