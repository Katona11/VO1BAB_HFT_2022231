using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO1BAB_HFT_202231.Models
{
    public class Employees
    {
        public string Name { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeesID { get; set; }

        public string ClassName { get; set; }

        public string PhoneNumer { get; set; }

        public string DateOfBirth { get; set; }

        

        public virtual ICollection<Cars> RentCar { get; set; }

        public Employees()
        {
            RentCar = new HashSet<Cars>();
        }

        public Employees(string path)
        {
            string[] splitarray = path.Split(",");
            Name = splitarray[0];
            EmployeesID = int.Parse(splitarray[1]);
            ClassName = splitarray[2];
            PhoneNumer = splitarray[3];
            DateOfBirth = splitarray[4];
            RentCar = new HashSet<Cars>();



        }
    }
}
