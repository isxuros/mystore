using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Employees
{
    public interface IEmployeeRepository
        : IRepository<Employee>
    {
    }
}
