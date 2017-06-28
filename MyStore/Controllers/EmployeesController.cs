using MyStore.Domain.Employees;
using MyStore.Domain.Models;
using MyStore.Infra.Data;
using MyStore.Infra.Data.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyStore.Controllers
{
    public class EmployeesController : ApiController
    {
        private IEmployeeRepository repository;
        public EmployeesController()
        {
            this.repository =
                new EmployeeRepository(new MyStoreDbContext());
        }

        public IHttpActionResult Get(string searchTerm)
        {
            try
            {
                Expression<Func<Employee, Boolean>> filter
                    = (e) => e.FirstName.Contains(searchTerm) ||
                             e.LastName.Contains(searchTerm);
                var employees =
            this.repository.Retrieve(filter,
                0, 10);

                
                return Ok(employees);
            }
            catch(Exception exc)
            {
                // log the error here...
                return InternalServerError();
            }
        }

        [Route(Name ="GetEmployee")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var employee = this.repository.Retrieve(id);

                if (employee== null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception exc)
            {
                // log the error here...
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                repository.Create(employee);
                return CreatedAtRoute<Employee>("GetEmployee",
                    new { id = employee.ID }, employee);
            }
            catch (Exception exc)
            {
                // log error here...
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, 
            [FromBody]Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (repository.Retrieve(id) == null)
                {
                    return NotFound();
                }

                repository.Update(id, employee);
                return Ok<Employee>(employee);
            } catch (Exception exc)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                repository.Delete(id);
                return Ok();
            } 
            catch(Exception exc)
            {
                return InternalServerError();
            }
        }
    }
}