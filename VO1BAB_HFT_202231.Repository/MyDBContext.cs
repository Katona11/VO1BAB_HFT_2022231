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







    }
}
