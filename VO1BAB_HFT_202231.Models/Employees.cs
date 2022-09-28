using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO1BAB_HFT_202231.Models
{
    class Employees
    {
        public string Name { get; set; }

        public int EmployeesId { get; set; }

        public int Class { get; set; }

        public string PhoneNumer { get; set; }

        public string DateOfBirth { get; set; }

        public ICollection<Cars> RentCarID { get; set; }
    }
}
