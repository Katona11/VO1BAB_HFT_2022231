using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO1BAB_HFT_202231.Models
{
    public class Employees
    {
        public string Name { get; set; }

        public int EmployeesId { get; set; }

        public string ClassName { get; set; }

        public string PhoneNumer { get; set; }

        public string DateOfBirth { get; set; }

        public int RentCarId { get; set; }

        public virtual ICollection<Cars> RentCar { get; set; }

        public Employees()
        {
            RentCar = new HashSet<Cars>();
        }

        public Employees(string path)
        {
            string[] splitarray = path.Split(",");
            Name = splitarray[0];
            EmployeesId = int.Parse(splitarray[1]);
            ClassName = splitarray[2];
            PhoneNumer = splitarray[3];
            DateOfBirth = splitarray[4];
            RentCarId = int.Parse(splitarray[5]);
           
        }
    }
}
