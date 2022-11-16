using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Models;
using static VO1BAB_HFT_202231.Logic.CarsLogic;

namespace VO1BAB_HFT_202231.Logic
{
    public interface ICarLogic
    {
        void Create(Cars item);

        void Delete(int id);

        Cars Read(int id);

        IEnumerable<Cars> ReadAll();

        void Update(Cars item);

        TheMostFamous TheMostFamousBrand();
    }
}
