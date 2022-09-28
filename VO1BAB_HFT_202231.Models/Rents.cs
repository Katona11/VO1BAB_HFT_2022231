using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO1BAB_HFT_202231.Models
{
   public  class Rents
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentId { get; set; }

        public string RentTime { get; set; }


        public int RentcarId { get; set; }

        public int EmployeesID{ get; set; }

        public virtual Cars CarId { get; private set; }

        public virtual Employees Employees { get; private set; }






    }
}
