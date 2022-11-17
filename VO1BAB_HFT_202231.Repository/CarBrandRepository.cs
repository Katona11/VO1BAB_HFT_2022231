using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_202231.Repository
{
    public class CarBrandRepository : Repository<CarBrand>
    {

        public CarBrandRepository(MyDBContext ctx) : base(ctx)
        {
        }

        public override CarBrand Read(int id)
        {
            return this.ctx.carbrand.FirstOrDefault(t => t.CarBrandID == id);
        }

        public override void Update(CarBrand id)
        {
            var olditem = Read(id.CarBrandID);
            foreach (var item in olditem.GetType().GetProperties())
            {
                if (item.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    item.SetValue(olditem, item.GetValue(id));
                }
            }
            ctx.SaveChanges();
        }
    }
}
