using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO1BAB_HFT_202231.Models
{
   public  class Rents
    {
        public int RentId { get; set; }

        public string RentTime { get; set; }


        public int RentcarId { get; set; }

        public int EmployeesID{ get; set; }

        public virtual Cars CarId { get; set; }

        public virtual Employees Employees { get; set; }




    }
}
