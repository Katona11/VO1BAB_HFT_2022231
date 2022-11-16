using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VO1BAB_HFT_202231.Models
{
   public  class Rents
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentId { get; set; }

        public string RentTime { get; set; }

        public string OwnerName { get; set; }



        public int CarsID { get; set; }

        [JsonIgnore]
        public virtual Cars cars { get; set; }

        public Rents(string path)
        {
            string[] array = path.Split(',');
            RentId = int.Parse(array[0]);
            RentTime = array[1];
            OwnerName = array[2];
            CarsID = int.Parse(array[3]);
        }
        public Rents()
        {

        }

       

        

       






    }
}
