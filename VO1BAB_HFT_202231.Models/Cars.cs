using System;

namespace VO1BAB_HFT_202231.Models
{
    public class Cars
    {
        public string Brand { get; set; }

        public int CarsID { get; set; }

        public string   Type { get; set; }

        public string LicensePlateNumber { get; set; }

        public int Year { get; set; }

        public int PerformanceInHP { get; set; }

        public int EmployeesId { get; set; }

        public Employees Owner { get; set; }

        public Cars(string path)
        {
            string[] splitarray = path.Split(",");
            Brand = splitarray[0];
            CarsID = int.Parse(splitarray[1]);
            Type = splitarray[2];
            LicensePlateNumber = splitarray[3];
            Year = int.Parse(splitarray[4]);
            PerformanceInHP = int.Parse(splitarray[4]);
            EmployeesId = int.Parse(splitarray[5]);
            
        }
    }
}
