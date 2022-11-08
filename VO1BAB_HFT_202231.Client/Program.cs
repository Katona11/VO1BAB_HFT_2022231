using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VO1BAB_HFT_202231.Models;
using VO1BAB_HFT_202231.Repository;

namespace VO1BAB_HFT_202231.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            MyDBContext ctx = new MyDBContext();
            CarsRepository repo = new CarsRepository(ctx);
           
            
            
            Console.ReadLine();
           
        }
    }
}
