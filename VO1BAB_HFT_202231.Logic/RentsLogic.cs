﻿using System;
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
            this.repo.Create(item);
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
    }
}
