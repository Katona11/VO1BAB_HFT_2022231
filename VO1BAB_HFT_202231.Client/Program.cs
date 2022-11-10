
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using VO1BAB_HFT_202231.Models;


namespace VO1BAB_HFT_202231.Client
{
    class Program
    {
        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Actor")
            {
               
                Console.WriteLine("Id" + "\t" + "Name");
                
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


            Console.ReadLine();
           
        }
    }
}
