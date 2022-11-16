﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VO1BAB_HFT_202231.Models
{
    public class Cars
    {
       

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarsID { get; set; }

        public int CarBrandID { get; set; }

        public string LicensePlateNumber { get; set; }

        public int Year { get; set; }

        public string Type { get; set; }

        public int PerformanceInHP { get; set; }



        public virtual ICollection<Rents> AllRents { get; set; }

        public virtual CarBrand CarBrand { get; set; } 

        

        public Cars(string path)
        {
            string[] splitarray = path.Split(',');

            CarBrandID = int.Parse(splitarray[0]);
            CarsID = int.Parse(splitarray[1]);
            Type = splitarray[2];
            LicensePlateNumber = splitarray[3];
            Year = int.Parse(splitarray[4]);
            PerformanceInHP = int.Parse(splitarray[5]);
            this.AllRents = new HashSet<Rents>();

          

        }
        public Cars()
        {
            this.AllRents = new HashSet<Rents>();

        }

    }
}
