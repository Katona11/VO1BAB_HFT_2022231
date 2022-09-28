using System;
using System.Collections.Generic;
using VO1BAB_HFT_202231.Models;
using VO1BAB_HFT_202231.Repository;

namespace VO1BAB_HFT_202231.Logic
{
    public class CarsLogic : ICarLogic
    {
        IRepository<Cars> repo;

        public CarsLogic(IRepository<Cars> repo)
        {
            this.repo = repo;
        }

        public void Create(Cars item)
        {
            if (item.Brand.Length<3)
            {
                throw new ArgumentException("The BrandName is too short!");
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
    }
}
