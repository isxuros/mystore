using MyStore.Domain.Employees;
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MyStore.Infra.Data.Employees
{
    public class EmployeeRepository:
        RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MyStoreDbContext context)
            :base(context)
        {

        }

        public override IEnumerable<Employee> Retrieve(Expression<Func<Employee, bool>> filter, int skip, int top)
        {
            return base.model.Include("Department")
                        .Where(filter)
                        .OrderBy(e => e.ID)
                        .Skip(skip)
                        .Take(top)
                        .ToList();
        }
    }
}
