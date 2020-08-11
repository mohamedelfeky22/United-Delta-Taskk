using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiOAuth2.Models;

namespace WebApiOAuth2.Controllers
{
    [Authorize]
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Employees
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }

        // GET: api/Employees/5
        [Route("api/Employees/{date}")]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(DateTime date)
        {
            IEnumerable<Employee> employee = db.Employees.Where(a => a.HiringDate.CompareTo(date) == 0).ToList();
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }


      

        
        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }


        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.Id == id) > 0;
        }
    }
}