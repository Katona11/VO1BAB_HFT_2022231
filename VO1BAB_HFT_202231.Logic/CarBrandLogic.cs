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
            var olditem = repo.ReadAll().FirstOrDefault(t => t.CarBrandID == item.CarBrandID);
            if (olditem!=null)
            {
                throw new ArgumentException("The Carbrand already exist!");
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

        public CarBrand Read(int id)
        {
            var item = this.repo.Read(id);
            if (item == null)
            {
                throw new Exception("The carbrand id not exist");
            }
            else
            {
                return item;
            }
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
