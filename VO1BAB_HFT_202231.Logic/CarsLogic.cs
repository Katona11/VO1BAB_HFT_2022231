﻿using System;
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
            var olditem = repo.ReadAll().FirstOrDefault(t => t.CarsID == item.CarsID);
            if (olditem != null)
            {
                throw new ArgumentException("The car  already exist!");
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

        //public record TheMostFamous(string name, int count);
        public  IEnumerable<TheMostFamous> TheMostFamousBrand()
        {
            var item = (from t in repo.ReadAll()
                        group t by t.CarBrand.Name into g
                        orderby g.Count() descending
                        select new TheMostFamous(g.Key,g.Count())).Take(1);

            return item;
            
            
        }
        //public record AvarageCarHP(string name,double avarage);

        public IEnumerable<AvarageCarHP> AvarageHPperCar()
        {

            var item = from t in repo.ReadAll()
                       group t by t.CarBrand.Name into g
                       select new AvarageCarHP(g.Key, g.Average(t => t.PerformanceInHP));

            return item;
                       

        }
        
       


    }
    public class TheMostFamous
    {
        public string name { get; set; }
        public int count { get; set; }

        public TheMostFamous(string name, int count)
        {
            this.name = name;
            this.count = count;
        }
        public TheMostFamous()
        {

        }

        public override bool Equals(object obj)
        {
            TheMostFamous b = obj as TheMostFamous;
            if (b==null)
            {
                return false;
            }
            else
            {
                return this.name == b.name && this.count == b.count;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.name, this.count);
        }
    }

    public class AvarageCarHP
    {
        public string name { get; set; }

        public double avarage { get; set; }

        public AvarageCarHP(string name, double avarage)
        {
            this.name = name;
            this.avarage = avarage;
        }

        public override bool Equals(object obj)
        {
            AvarageCarHP b = obj as AvarageCarHP;
            if (b==null)
            {
                return false;
            }
            else
            {
               return  this.name == b.name && this.avarage == b.avarage;

            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.name, this.avarage);
        }
    }
}
