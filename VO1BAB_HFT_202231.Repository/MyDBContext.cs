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


            //modelBuilder.Entity<Employees>(emplyes => emplyes
            //.HasMany(t=>t.RentCar).WithOne(t=>t.Owner).




            modelBuilder.Entity<Rents>().HasOne(t => t.CarId).WithOne(t => t.Owner);

            modelBuilder.Entity<Rents>().HasOne(t => t.Employees).WithMany(t => t.RentCar).HasForeignKey(t => t.EmployeesID);



            //modelBuilder.Entity<Cars>()
            //.HasMany(x => x.Owner)
            //.WithMany(x => x.RentCar)
            //.UsingEntity<Rents>(
            //x=> x.HasOne(t=>t.CarId).WithMany().HasForeignKey(t=>t.RentcarId).OnDelete(DeleteBehavior.Cascade),
            //x=> x.HasOne
           
            
               
           






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
