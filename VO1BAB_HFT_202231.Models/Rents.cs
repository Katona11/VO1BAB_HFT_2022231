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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public override bool Equals(object obj)
        {
            Rents b = obj as Rents;
            if (b==null)
            {
                return false;
            }
            else
            {
                return this.RentId == b.RentId && this.RentTime == b.RentTime;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.RentId, this.RentTime);
        }



    }
}
