using Microsoft.EntityFrameworkCore;
using System;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_202231.Repository
{
    public class MyDBContext:DbContext
    {
        public DbSet<Cars> cars { get; set; }

        public DbSet<Employees> employess { get; set; }

        public DbSet<Rents> rents { get; set; }

        public MyDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("data").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Cars>(cars => cars
            .HasOne(x => x.Owner)
            .WithMany(x => x.RentCar)
            .HasForeignKey(x => x.EmployeesId)
            .OnDelete(DeleteBehavior.Cascade));





            modelBuilder.Entity<Cars>().HasData(new Cars[]
            {

            });

            modelBuilder.Entity<Employees>().HasData(new Employees[]
            {

            });

           modelBuilder.Entity<Rents>().HasData(new Rents[]
           {

           });


        }




    }
}
