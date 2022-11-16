using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_202231.Repository
{
    public class MyDBContext:DbContext
    {
        public DbSet<Cars> cars { get; set; }

        public DbSet<CarBrand> carbrand { get; set; }

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




            modelBuilder.Entity<Cars>(t => t.HasMany(t => t.AllRents).WithOne(t => t.cars).HasForeignKey(t => t.RentId));
            modelBuilder.Entity<Cars>(t => t.HasOne(t => t.CarBrand).WithMany(t => t.Cars).HasForeignKey(t => t.CarBrandID));
            

           



            //modelBuilder.Entity<Cars>()
            //.HasMany(x => x.Owner)
            //.WithMany(x => x.RentCar)
            //.UsingEntity<Rents>(
            //x=> x.HasOne(t=>t.CarId).WithMany().HasForeignKey(t=>t.RentcarId).OnDelete(DeleteBehavior.Cascade),
            //x=> x.HasOne



            modelBuilder.Entity<Rents>().HasData(new Rents[]
            {
                new Rents("1,2022-10-11,Kovács Attila,1"),
                new Rents("2,2022-10-11,Kovács Anna,2"),
                new Rents("3,2022-10-11,Lakatos Béla,1")
            });


            modelBuilder.Entity<CarBrand>().HasData(new CarBrand[]
            {
                new CarBrand("1,BMW"),
                new CarBrand("2,Mercedes-Benz"),
                new CarBrand("3,Ford"),
                new CarBrand("4,Skoda"),
                new CarBrand("5,Audi"),
                new CarBrand("6,Kia"),
                new CarBrand("7,Opel")


            });





            modelBuilder.Entity<Cars>().HasData(new Cars[]
            {
                //25 car 
                new Cars("1,1,E60,HFG-453,2004,310"),
                new Cars("2,2,CLS-63,SNK-955,2019,605"),
                new Cars("3,3,Mondeo,JPK-245,2008,110"),
                new Cars("3,4,Mondeo,KLK-615,2009,130"),
                new Cars("4,5,Ocatavia,MIH-400,2014,150"),
                new Cars("5,6,A3,P-55332,2016,150"),
                new Cars("5,7,A3,P-55456,2016,150"),
                new Cars("6,8,Creed,SEZ-488,2016,190"),
                new Cars("4,9,Kodiaq,SBC-888,2018,200"),
                new Cars("4,10,Superb,HCD-104,2010,200"),
                new Cars("7,11,Astra,PET-555,2004,90"),
                new Cars("4,12,Octavia,JKL-256,2004,80"),
                new Cars("1,13,530D,KCI-442,2011,190"),
                new Cars("2,14,CLA,ONS-875,2017,220"),
                new Cars("2,15,CLA,OCC-325,2017,220"),
                new Cars("2,16,CLA,OBS-432,2017,220"),
                new Cars("4,17,Octvia,PRS-564,2018,150"),
                new Cars("5,18,E-TRON,AA-AA-343,2022,400"),
                new Cars("4,19,Kodiaq,AA-AY-789,2022,160"),
                new Cars("1,20,M5,AA-AV-121,2022,700"),
                new Cars("1,21,E60,HFG-453,2004,310"),//Szallitokocsik innentol
                new Cars("1,22,E60,HFG-453,2004,310"),
                new Cars("1,23,E60,HFG-453,2004,310"),
                new Cars("1,24,E60,HFG-453,2004,310"),
                new Cars("1,25,E60,HFG-453,2004,310"),
                



            }) ;

            //modelBuilder.Entity<Employees>().HasData(new Employees[]
            //{
            //    //100 employees
            //    new Employees("Nagy Marcell,1,Management,+367075168691,1961-10-24"),
            //    new Employees("Károlyi Lilla,2,Programmers,+367044395260,1957-11-27"),
            //    new Employees("Szőke Alexandra,3,Programmers,+367042119345,1952-03-05"),
            //    new Employees("Katona Marcell,4,Programmers,+367069748704,1977-09-16"),
            //    new Employees("Farkas Dániel,5,Other Workers,+367042791469,1980-07-19"),
            //    new Employees("Katona Béla,6,Other Workers,+367031875142,1959-05-03"),
            //    new Employees("Medgyesi Mónika,7,Other Workers,+367074667718,1972-03-20"),
            //    new Employees("Kovács Bence,8,Administrator,+367031897113,1996-09-26"),
            //    new Employees("Farkas Miklós,9,Management,+367003859710,1997-12-04"),
            //    new Employees("Cséfalvay Bence,10,Administrator,+367076134780,1976-01-28"),
            //    new Employees("Szabó Koppány,11,Programmers,+367069733970,1969-02-07"),
            //    new Employees("Kiss Alexandra,12,Programmers,+367028844552,1982-05-29"),
            //    new Employees("Medgyesi Dávid,13,Other Workers,+367097668749,1960-10-29"),
            //    new Employees("Katona Bence,14,Administrator,+367029142675,1961-05-30"),
            //    new Employees("Cséfalvay Koppány,15,Programmers,+367033476815,1976-07-04"),
            //    new Employees("Medgyesi Koppány,16,Programmers,+367070558896,1961-06-11"),
            //    new Employees("Medgyesi Bálint,17,Programmers,+367052759058,1969-03-07"),
            //    new Employees("Lakatos Marcell,18,Administrator,+367046357481,1993-05-16"),
            //    new Employees("Kiss Alexandra,19,Other Workers,+367019396702,1996-07-24"),
            //    new Employees("Bátory Alex,20,Other Workers,+367073382215,1959-10-28"),
            //    new Employees("Bátory Alexandra,21,Programmers,+367043196764,1992-04-11"),
            //    new Employees("Katona Marcell,22,Management,+367077806934,2000-08-25"),
            //    new Employees("Kovács Marcell,23,Administrator,+367076083584,1973-10-07"),
            //    new Employees("Kiss Zsófia,24,Programmers,+367061536883,1999-11-05"),
            //    new Employees("Béres Attila,25,Management,+367044141061,1961-07-16"),
            //    new Employees("Nagy Alexandra,26,Programmers,+367030867088,1955-05-16"),
            //    new Employees("Bátory Alex,27,Programmers,+367071694709,1985-09-27"),
            //    new Employees("Varga Dániel,28,Programmers,+367099854508,1954-07-23"),
            //    new Employees("Lakatos Bálint,29,Administrator,+367037932340,1995-07-20"),
            //    new Employees("Medgyesi Bálint,30,Programmers,+367030754381,1978-12-12"),
            //    new Employees("Varga Dávid,31,Other Workers,+367001145459,1990-07-28"),
            //    new Employees("Cséfalvay Áron,32,Other Workers,+367013973650,1989-03-16"),
            //    new Employees("Katona Bence,33,Management,+367020900696,1971-02-05"),
            //    new Employees("Bátory Alex,34,Programmers,+367032623992,1952-08-30"),
            //    new Employees("Medgyesi Dávid,35,Management,+367040966377,1980-11-09"),
            //    new Employees("Farkas Gergő,36,Programmers,+367097558064,1978-04-16"),
            //    new Employees("Bátory Zsófia,37,Management,+367093132823,1960-06-03"),
            //    new Employees("Béres Bence,38,Administrator,+367068900523,1954-06-25"),
            //    new Employees("Cséfalvay Tamás,39,Other Workers,+367046190772,1990-11-04"),
            //    new Employees("Nagy Lilla,40,Administrator,+367050443177,1968-06-24"),
            //    new Employees("Kásás Bence,41,Administrator,+367026504385,1967-03-12"),
            //    new Employees("Kiss Alex,42,Programmers,+367000993770,2003-05-29"),
            //    new Employees("Cséfalvay Lilla,43,Other Workers,+367036139100,1968-01-19"),
            //    new Employees("Katona Lőrinc,44,Management,+367072033363,1980-10-13"),
            //    new Employees("Lakatos Gergő,45,Management,+367062111116,1952-01-02"),
            //    new Employees("Medgyesi Tamás,46,Other Workers,+367068340627,1965-08-30"),
            //    new Employees("Bátory Réka,47,Other Workers,+367013902831,2002-05-22"),
            //    new Employees("Károlyi Kitti,48,Management,+367020269667,1973-12-29"),
            //    new Employees("Varga Áron,49,Other Workers,+367095239147,1955-01-14"),
            //    new Employees("Károlyi Marcell,50,Administrator,+367089848152,1967-04-27"),
            //    new Employees("Béres Miklós,51,Programmers,+367090008314,1957-04-19"),
            //    new Employees("Medgyesi Marcell,52,Administrator,+367092230084,1956-06-12"),
            //    new Employees("Katona Alexandra,53,Administrator,+367019558081,2001-06-22"),
            //    new Employees("Varga Tamás,54,Programmers,+367085814030,1951-06-13"),
            //    new Employees("Szabó Mónika,55,Programmers,+367086609521,1990-01-27"),
            //    new Employees("Tóth Lőrinc,56,Other Workers,+367028786466,1979-03-11"),
//new Employees(Farkas Dávid,57,Management,+367090145323,1992-8-9),
//new Employees(Szőke Attila,58,Administrator,+367078393571,1990-8-22),
//new Employees(Kiss Alex,59,Programmers,+367014752126,1998-5-30),
//new Employees(Szabó Dániel,60,Other Workers,+367000574986,1998-5-4),
//new Employees(Bátory Dávid,61,Other Workers,+367035855913,2000-10-22),
//new Employees(Szőke Alexandra,62,Management,+367099099816,1954-12-19),
//new Employees(Bátory Tamás,63,Programmers,+367053448433,1979-5-24),
//new Employees(Medgyesi Alex,64,Administrator,+367017055779,1968-2-25),
//new Employees(Béres Marcell,65,Administrator,+367048975785,1969-3-1),
//new Employees(Lakatos Alex,66,Administrator,+367046230453,1998-2-7),
//new Employees(Károlyi Lőrinc,67,Administrator,+367092638696,1973-12-3),
//new Employees(Kiss Bence,68,Administrator,+367048550157,1998-6-15),
//new Employees(Kovács Attila,69,Management,+367098590360,1981-8-6),
//new Employees(Nagy Marcell,70,Administrator,+367012207090,1981-8-19),
//new Employees(Tóth Attila,71,Programmers,+367031965775,1969-2-29),
//new Employees(Farkas Gergő,72,Programmers,+367028495756,1965-6-13),
//new Employees(Lakatos Bálint,73,Other Workers,+367029352374,1986-6-17),
//new Employees(Szőke Áron,74,Administrator,+367090131586,1960-9-1),
//new Employees(Cséfalvay Bence,75,Other Workers,+367085255824,1992-5-6),
//new Employees(Károlyi Dániel,76,Other Workers,+367029367962,1967-2-26),
//new Employees(Medgyesi Áron,77,Administrator,+367076596951,1959-12-11),
//new Employees(Nagy Dávid,78,Programmers,+367027159042,1965-5-17),
//new Employees(Bátory Attila,79,Administrator,+367012799660,1991-3-31),
//new Employees(Medgyesi Zsófia,80,Management,+367074366195,2002-3-21),


          


        }




    }
}
