using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Models;
using VO1BAB_HFT_202231.Repository;

namespace VO1BAB_HFT_202231.Logic
{
    public class CarBrandLogic : ICarBrandLogic
    {
        IRepository<CarBrand> repo;

        public CarBrandLogic(IRepository<CarBrand> repo)
        {
            this.repo = repo;
        }

        public void Create(CarBrand item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public CarBrand Read(int id)
        {
            return this.Read(id);
        }

        public IEnumerable<CarBrand> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(CarBrand item)
        {
            this.repo.Update(item);

        }
    }
}
