using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Repository.Repos
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        private DbContext ctx;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        public abstract T GetById(int id);


        public void InsertElement(T newElement)
        {
            this.ctx.Set<T>().Add(newElement);
            this.ctx.SaveChanges();
        }

        public abstract void RemoveById(int id);

    }
}
