using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO1BAB_HFT_202231.Models
{
    public class CarBrand
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarBrandID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cars>  Cars{get;set;}

        

        public CarBrand(string path)
        {
            string[] array = path.Split(',');
            this.CarBrandID = int.Parse(array[0]);
            this.Name = array[1];
            
            
        }
        public CarBrand()
        {

        }
    }
}
