using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_202231.Repository
{
    public class CarsRepository : Repository<Cars>
    {
        public CarsRepository(MyDBContext ctx) : base(ctx)
        {
        }

        public override Cars Read(int id)
        {
            return this.ctx.cars.FirstOrDefault(t => t.CarsID == id);
        }

        public override void Update(Cars id)
        {
            var olditem = Read(id.CarsID);
            foreach (var item in olditem.GetType().GetProperties())
            {
                item.SetValue(olditem, item.GetValue(id));
            }
        }
    }
}
