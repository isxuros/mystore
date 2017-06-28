using MyStore.Domain;
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infra.Data
{
    public abstract class RepositoryBase<T>
         : IRepository<T> where T : EntityBase
    {
        protected MyStoreDbContext context;
        protected DbSet<T> model;
        public RepositoryBase(MyStoreDbContext context)
        {
            this.context = context;
            this.model = context.Set<T>();

        }
        public T Create(T newObject)
        {
            this.model.Add(newObject);
            this.context.SaveChanges();
            return newObject;
        }

        public void Delete(object id)
        {
            var objectToDelete = Retrieve(id);
            this.model.Remove(objectToDelete);
            this.context.SaveChanges();
        }

        public T Retrieve(object id)
        {
            var obj = this.model.Find(id);
            return obj;
        }

        public virtual IEnumerable<T> Retrieve(Expression<Func<T,Boolean>> filter,
            int skip, int top)
        {
            return this.model
                    .AsNoTracking()
                    .Where(filter)
                    .OrderBy(e=>e.ID)
                    .Skip(skip)
                    .Take(top)
                    .ToList();
                    
        }

        public T Update(object id, T modifiedObject)
        {
            this.context.Entry<T>(modifiedObject).State
                = EntityState.Modified;
            this.context.SaveChanges();
            return modifiedObject;
        }
    }
}
