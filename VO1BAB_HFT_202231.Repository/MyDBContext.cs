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
                //25 car 
                new Cars("BMW,1,E60,HFG-453,2004,310"),
                new Cars("Mercedes-Benz,2,CLS-63,SNK-955,2019,605"),
                new Cars("Ford,3,Mondeo,JPK-245,2008,110"),
                new Cars("Ford,4,Mondeo,KLK-615,2009,130"),
                new Cars("Skoda,5,Ocatavia,MIH-400,2014,150"),
                new Cars("Audi,6,A3,P-55332,2016,150"),
                new Cars("Audi,7,A3,P-55456,2016,150"),
                new Cars("Kia,8,Creed,SEZ-488,2016,190"),
                new Cars("Skoda,9,Kodiaq,SBC-888,2018,200"),
                new Cars("Skoda,10,Superb,HCD-104,2010,200"),
                new Cars("Opel,11,Astra,PET-555,2004,90"),
                new Cars("Skoda,12,Octavia,JKL-256,2004,80"),
                new Cars("BMW,13,530D,KCI-442,2011,190"),
                new Cars("Mercedes-Benz,14,CLA,ONS-875,2017,220"),
                new Cars("Mercedes-Benz,15,CLA,OCC-325,2017,220"),
                new Cars("Mercedes-Benz,16,CLA,OBS-432,2017,220"),
                new Cars("Skoda,17,Octvia,PRS-564,2018,150"),
                new Cars("Audi,18,E-TRON,AA-AA-343,2022,400"),
                new Cars("Skoda,19,Kodiaq,AA-AY-789,2022,160"),
                new Cars("BMW,20,M5,AA-AV-121,2022,700"),
                new Cars("BMW,21,E60,HFG-453,2004,310"),//Szallitokocsik innentol
                new Cars("BMW,22,E60,HFG-453,2004,310"),
                new Cars("BMW,23,E60,HFG-453,2004,310"),
                new Cars("BMW,24,E60,HFG-453,2004,310"),
                new Cars("BMW,25,E60,HFG-453,2004,310"),
                



            }) ;

            modelBuilder.Entity<Employees>().HasData(new Employees[]
            {

            });

           modelBuilder.Entity<Rents>().HasData(new Rents[]
           {

           });


        }




    }
}
