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

        public Employees Owner { get; set; }




    }
}
