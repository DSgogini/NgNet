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
using ConsServer.Models;

namespace ConsServer.Controllers
{
    public class EmployeeEntitiesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EmployeeEntities
        public IQueryable<EmployeeEntity> GetEmployee()
        {
            return db.Employee;
        }

        // GET: api/EmployeeEntities/5
        [ResponseType(typeof(EmployeeEntity))]
        public IHttpActionResult GetEmployeeEntity(int id)
        {
            EmployeeEntity employeeEntity = db.Employee.Find(id);
            if (employeeEntity == null)
            {
                return NotFound();
            }

            return Ok(employeeEntity);
        }

        // PUT: api/EmployeeEntities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployeeEntity(int id, EmployeeEntity employeeEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeEntity.Id)
            {
                return BadRequest();
            }

            db.Entry(employeeEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmployeeEntities
        [ResponseType(typeof(EmployeeEntity))]
        public IHttpActionResult PostEmployeeEntity(EmployeeEntity employeeEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employee.Add(employeeEntity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employeeEntity.Id }, employeeEntity);
        }

        // DELETE: api/EmployeeEntities/5
        [ResponseType(typeof(EmployeeEntity))]
        public IHttpActionResult DeleteEmployeeEntity(int id)
        {
            EmployeeEntity employeeEntity = db.Employee.Find(id);
            if (employeeEntity == null)
            {
                return NotFound();
            }

            db.Employee.Remove(employeeEntity);
            db.SaveChanges();

            return Ok(employeeEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeEntityExists(int id)
        {
            return db.Employee.Count(e => e.Id == id) > 0;
        }
    }
}