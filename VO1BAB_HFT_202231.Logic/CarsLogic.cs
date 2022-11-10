using System;
using System.Collections.Generic;
using System.Linq;
using VO1BAB_HFT_202231.Models;
using VO1BAB_HFT_202231.Repository;

namespace VO1BAB_HFT_202231.Logic
{
    public class CarsLogic : ICarLogic
    {
        IRepository<Cars> repo;
        IRepository<CarBrand> carbranrepo;

        public CarsLogic(IRepository<Cars> repo)
        {
            this.repo = repo;
        }

        public void Create(Cars item)
        {
            if (item.Year<1950)
            {
                throw new ArgumentException("The year is too short!");
            }
            else
            {
                this.repo.Create(item);
            }
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Cars Read(int id)
        {
            var item = this.repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("The Car not exist!");
            }
            else
            {
                return item;
            }
        }

        public IEnumerable<Cars> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Cars item)
        {
            this.repo.Update(item);
        }
        public IEnumerable<int> TheMostFamousBrand()
        {
            return from t in repo.ReadAll()
                   join y in carbranrepo.ReadAll()
                   on t.CarBrandID equals y.CarBrandID
                   group t by t.CarBrandID into g
                   orderby g.Count() descending
                   select g.Key;

        }
    }
}
