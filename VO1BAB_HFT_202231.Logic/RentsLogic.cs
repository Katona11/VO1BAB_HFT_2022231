using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Models;
using VO1BAB_HFT_202231.Repository;

namespace VO1BAB_HFT_202231.Logic
{
    public class RentsLogic : IRentsLogic
    {
        IRepository<Rents> repo;

        public RentsLogic(IRepository<Rents> repo)
        {
            this.repo = repo;
        }

        public void Create(Rents item)
        {
            var olditem = repo.ReadAll().FirstOrDefault(t => t.RentId == item.RentId);
            if (olditem!=null)
            {
                throw new ArgumentException("The rent already exist!");
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

        public Rents Read(int id)
        {
            var item = this.repo.Read(id);
            if (item == null)
            {
                throw new Exception("The rents id not exist");
            }
            else
            {
                return item;
            }
        }

        public IEnumerable<Rents> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Rents item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<string> TheRentsCarBrand()
        {
            var item = from t in repo.ReadAll()
                       select t.cars.CarBrand.Name;

            return item;

        }
        //public record BrandperRentsCount(string brand, int count);
        public IEnumerable<BrandperRentsCount> BrandperRentsCountsMethod()
        {
            var item = from t in repo.ReadAll()
                       group t by t.cars.CarBrand.Name into g
                       select new BrandperRentsCount(g.Key, g.Count());

            return item;
        }
        public IEnumerable<YearInfo> YearStatistics()
        {
            var item = from t in repo.ReadAll()
                       group t by int.Parse(t.RentTime.Substring(0, 4)) into g
                       select new YearInfo(g.Key, g.Count());
            return item;
        }





    }
    public class BrandperRentsCount
    {
        public string brand { get; set; }

        public int count { get; set; }

        public BrandperRentsCount(string brand, int count)
        {
            this.brand = brand;
            this.count = count;
        }
        public override bool Equals(object obj)
        {
            BrandperRentsCount b = obj as BrandperRentsCount;
            if (b==null)
            {
                return false;
            }
            else
            {
                return this.brand == b.brand && this.count == b.count;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.brand, this.count);
        }
        public BrandperRentsCount()
        {

        }
    }

    public class YearInfo
    {
        public int Year { get; set; }

        public int Count { get; set; }

        public YearInfo(int year, int count)
        {
            Year = year;
            Count = count;
        }
        public override bool Equals(object obj)
        {
            YearInfo b = obj as YearInfo;
            if (b==null)
            {
                return false;

            }
            else
            {
                return this.Year == b.Year && this.Count == b.Count;
            }

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Year, this.Count); 
        }
    }


}
