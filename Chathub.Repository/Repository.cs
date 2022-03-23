using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chathub.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected MessageDBContext ctx;
        public Repository(MessageDBContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Get(id));
            ctx.SaveChanges();
        }


        public IQueryable<T> GetAll()
        {
             return ctx.Set<T>();
        }

        public abstract T Get(int id);
        public abstract void Update(T entity);
    }
}
