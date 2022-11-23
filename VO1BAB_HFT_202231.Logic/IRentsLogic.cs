using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Models;
using static VO1BAB_HFT_202231.Logic.RentsLogic;

namespace VO1BAB_HFT_202231.Logic
{
    public interface IRentsLogic
    {
        void Create(Rents item);

        void Update(Rents item);

        void Delete(int id);

        Rents Read(int id);

        IEnumerable<Rents> ReadAll();

        IEnumerable<string> TheRentsCarBrand();

        IEnumerable<BrandperRentsCount> BrandperRentsCountsMethod();

        IEnumerable<YearInfo> YearStatistics();
    }
}
