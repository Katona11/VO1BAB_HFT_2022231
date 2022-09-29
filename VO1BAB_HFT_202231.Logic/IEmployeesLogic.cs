using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_202231.Logic
{
    interface IEmployeesLogic
    {
        void Create(Employees item);

        void Delete(int id);

        void Update(Employees item);

        Employees Read(int id);

        IEnumerable<Employees> ReadAll();
    }
}
