using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_202231.Logic
{
    interface ICarBrandLogic
    {
        void Create(CarBrand item);

        void Update(CarBrand item);

        void Delete(int id);

        CarBrand Read(int id);

        IEnumerable<CarBrand> ReadAll();
    }
}
