using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_202231.Logic
{
    interface IRentsLogic
    {
        void Create(Rents item);

        void Update(Rents item);

        void Delete(int id);

        Rents Read(int id);

        IEnumerable<Rents> ReadAll();
    }
}
