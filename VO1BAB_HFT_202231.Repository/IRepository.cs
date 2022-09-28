using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO1BAB_HFT_202231.Repository
{
    interface IRepository<T> where T:class
    {
        T Read(int id);

        IQueryable<T> ReadAll();

        void Create(T item);

        void Delete(int id);

        void Update(int id);
    }
}
