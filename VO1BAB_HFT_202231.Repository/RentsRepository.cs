using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_202231.Repository
{
    public class RentsRepository : Repository<Rents>
    {
        public RentsRepository(MyDBContext ctx) : base(ctx)
        {
        }

        public override Rents Read(int id)
        {
            return ctx.rents.FirstOrDefault(t => t.RentId == id);
        }

        public override void Update(Rents id)
        {
            var olditem = Read(id.RentId);
            foreach (var item in olditem.GetType().GetProperties())
            {
                item.SetValue(olditem, item.GetValue(id));
            }
        }
    }
}
