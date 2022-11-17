
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
            if (entity == "Car") 
            {
                Console.WriteLine("Enter the Car's Id: ");
                int id = int.Parse(Console.ReadLine());
                Cars one = rest.Get<Cars>(id, "car");

                Console.WriteLine($"Enter the new id[old: {one.CarsID}]");
                int carsid = int.Parse(Console.ReadLine());
                one.CarsID = carsid;

                Console.WriteLine($"Enter the new CarBrandId[old: {one.CarBrandID}]: ");
                int carbrandid = int.Parse(Console.ReadLine());
                one.CarBrandID = carbrandid;

                Console.WriteLine($"Enter the new LicensePlateNumber[old: {one.LicensePlateNumber}]: ");
                string licenseplatenumberstring = Console.ReadLine();
                one.LicensePlateNumber = licenseplatenumberstring;


                Console.WriteLine($"Enter the new  HorsePower[old: {one.PerformanceInHP}]: ");
                int horsepower = int.Parse(Console.ReadLine());
                one.PerformanceInHP = horsepower;

                Console.WriteLine($"Enter the new Car Type[old: {one.Type}]: ");
                string cartype = Console.ReadLine();
                one.Type = cartype;

                Console.WriteLine($"Enter the new car  year[old: {one.Year}]: ");
                int year = int.Parse(Console.ReadLine());
                one.Year = year;

                rest.Put(one, "car");
            }
            else if (entity == "CarBrand")
            {
                Console.WriteLine("Enter the CarBrand's Id: ");
                int id = int.Parse(Console.ReadLine());
                CarBrand one = rest.Get<CarBrand>(id, "carbrand");

                Console.WriteLine($"Enter the new CarBrandId[old: {one.CarBrandID}]: ");
                int carbrandid = int.Parse(Console.ReadLine());
                one.CarBrandID = carbrandid;

                Console.WriteLine($"Enter the new CarBrand Name[old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;

                rest.Put(one, "carbrand");


            }
            else if (entity=="Rents")
            {
                Console.WriteLine("Enter the Rent's Id: ");
                int id = int.Parse(Console.ReadLine());
                Rents one = rest.Get<Rents>(id, "rents");

                Console.WriteLine($"Enter the new RentID[old: {one.RentId}]: ");
                int rentId = int.Parse(Console.ReadLine());
                one.RentId = rentId;


                Console.WriteLine($"Enter the new  RentTime[old: {one.RentTime}]: ");
                string renttime = Console.ReadLine();
                one.RentTime = renttime;


                Console.WriteLine($"Enter the new Owner Name[old: {one.OwnerName}]: ");
                string ownername = Console.ReadLine();
                one.OwnerName = ownername;


                Console.WriteLine($"Enter the new CarId[old: {one.CarsID}]: ");
                int carid = int.Parse(Console.ReadLine());
                one.CarsID = carid;

                rest.Put(one, "rents");


            }
            //Console.ReadLine();
        }
        static void Delete(string entity)
        {

            if (entity == "Car")
            {
                Console.WriteLine("Enter the Car's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "car");
            }
            else if (entity == "CarBrand")
            {
                Console.WriteLine("Enter the CarBrand's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "carbrand");
            }
            else if (entity == "Rents")
            {
                Console.WriteLine("Enter the Rent's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "rents");
            }
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
