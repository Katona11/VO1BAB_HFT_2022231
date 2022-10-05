using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VO1BAB_HFT_202231.Models
{
    public class Cars
    {
        public string Brand { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentcarId { get; set; }

        public string   Type { get; set; }

        public string LicensePlateNumber { get; set; }

        public int Year { get; set; }

        public int PerformanceInHP { get; set; }

        //public int EmployeesId { get; set; }

        public virtual Rents Owner { get; set; }

        public Cars(string path)
        {
            string[] splitarray = path.Split(",");
            Brand = splitarray[0];
            RentcarId = int.Parse(splitarray[1]);
            Type = splitarray[2];
            LicensePlateNumber = splitarray[3];
            Year = int.Parse(splitarray[4]);
            PerformanceInHP = int.Parse(splitarray[4]);
            //EmployeesId = int.Parse(splitarray[5]);
            //Owner = new HashSet<Employees>();

        }
        public Cars()
        {
            //Owner = new HashSet<Employees>();
        }
    }
}
