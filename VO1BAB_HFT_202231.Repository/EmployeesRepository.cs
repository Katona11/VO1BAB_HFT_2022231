using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_202231.Repository
{
    class EmployeesRepository : Repository<Employees>
    {
        public EmployeesRepository(MyDBContext ctx) : base(ctx)
        {
        }

        public override Employees Read(int id)
        {
            return this.ctx.employess.FirstOrDefault(t => t.EmployeesId == id);
        }

        public override void Update(Employees id)
        {
            var olditem = Read(id.EmployeesId);
            foreach (var item in olditem.GetType().GetProperties())
            {
                item.SetValue(olditem, item.GetValue(id));
            }
        }
    }
}
