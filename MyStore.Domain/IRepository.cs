using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain
{
    public interface IRepository<T>
        where T : EntityBase
    {
        T Create(T newObject);

        T Retrieve(object id);

        IEnumerable<T> Retrieve(Expression<Func<T,Boolean>> filter,
            int skip, int top);

        T Update(object id, T modifiedObject);

        void Delete(object id);
    }
}
