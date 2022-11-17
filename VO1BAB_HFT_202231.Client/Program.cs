
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;

using VO1BAB_HFT_202231.Models;


namespace VO1BAB_HFT_202231.Client
{
    internal class Program
    {
        static RestService rest;
        

        static void Create(string entity)
        {
            if (entity == "Car")
            {
                Console.WriteLine("Enter the CarId: ");
                int carid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the CarBrandId: ");
                int carbrandid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the LicensePlateNumber: ");
                string licenseplatenumberstring = Console.ReadLine();
                Console.WriteLine("Enter the HorsePower: ");
                int horsepower = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Car Type: ");
                string cartype = Console.ReadLine();
                Console.WriteLine("Enter the year: ");
                int year = int.Parse(Console.ReadLine());
                rest.Post(new Cars()
                {
                    CarsID = carid,
                    CarBrandID = carbrandid,
                    LicensePlateNumber = licenseplatenumberstring,
                    PerformanceInHP = horsepower,
                    Type = cartype,
                    Year = year
                },"car");


            }
            else if (entity == "CarBrand")
            {
                Console.WriteLine("Enter the CarBrandId: ");
                int carbrandid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the CarBrand Name: ");
                string name = Console.ReadLine();
                rest.Post(new CarBrand()
                {
                    CarBrandID = carbrandid,
                    Name = name
                }, "carbrand");
            }
            else if (entity == "Rents")
            {
                Console.WriteLine("Enter the RentID: ");
                int rentId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the RentTime: ");
                string renttime = Console.ReadLine();
                Console.WriteLine("Enter the Owner Name: ");
                string ownername = Console.ReadLine();
                Console.WriteLine("Enter the CarId: ");
                int carid = int.Parse(Console.ReadLine());
                rest.Post(new Rents()
                {
                    RentId = rentId,
                    RentTime = renttime,
                    OwnerName = ownername,
                    CarsID = carid
                }, "rents");

            }

        }
        static void List(string entity)
        {
            if (entity == "Car")
            {
                List<Cars> cars = rest.Get<Cars>("cars");
                foreach (var item in cars)
                {
                    Console.WriteLine($" {item.CarsID} {item.CarBrandID} {item.LicensePlateNumber} {item.PerformanceInHP} {item.Type} {item.Year}");

                }


            }
            else if (entity == "CarBrand")
            {
                List<CarBrand> carbrand = rest.Get<CarBrand>("carbrand");
                foreach (var item in carbrand)
                {
                    Console.WriteLine($"{item.CarBrandID} {item.Name}");

                }
            }

            else if (entity == "Rents")
            {
                List<Rents> rents = rest.Get<Rents>("rents");
                foreach (var item in rents)
                {
                    Console.WriteLine($"{item.RentId} {item.RentTime} {item.OwnerName} {item.CarsID}");

                }
            }

            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:50437/", "cars");
           


            var carSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Car"))
                .Add("Create", () => Create("Car"))
                .Add("Delete", () => Delete("Car"))
                .Add("Update", () => Update("Car"))
                .Add("Exit", ConsoleMenu.Close);

            var carbrandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("CarBrand"))
                .Add("Create", () => Create("CarBrand"))
                .Add("Delete", () => Delete("CarBrand"))
                .Add("Update", () => Update("CarBrand"))
                .Add("Exit", ConsoleMenu.Close);

            var rentsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Rents"))
                .Add("Create", () => Create("Rents"))
                .Add("Delete", () => Delete("Rents"))
                .Add("Update", () => Update("Rents"))
                .Add("Exit", ConsoleMenu.Close);

           


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Car", () => carSubMenu.Show())
                .Add("CarBrand", () => carbrandSubMenu.Show())
                .Add("Rents", () => rentsSubMenu.Show())
                
                .Add("Exit", ConsoleMenu.Close);

            
            menu.Show();
            

        }
    }
}
