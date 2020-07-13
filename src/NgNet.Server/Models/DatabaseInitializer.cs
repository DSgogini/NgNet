using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ConsServer.Models
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var emp = new List<EmployeeEntity>()
            {
                new EmployeeEntity() { Id = 1, FirstName = "JP", LastName = "Player", Address = "noIda", Email = "join@gmail.com", Phone = "12345678990" },
                new EmployeeEntity() { Id = 2, FirstName = "Virat", LastName = "Player", Address = "noIda", Email = "join@gmail.com", Phone = "12345678990" },
                new EmployeeEntity() { Id = 3, FirstName = "Aman", LastName = "Player", Address = "noIda", Email = "join@gmail.com", Phone = "12345678990" },
                new EmployeeEntity() { Id = 4, FirstName = "Kohoi", LastName = "Player", Address = "noIda", Email = "join@gmail.com", Phone = "12345678990" },
                new EmployeeEntity() { Id = 5, FirstName = "Haynki", LastName = "Player", Address = "noIda", Email = "join@gmail.com", Phone = "12345678990" },
                new EmployeeEntity() { Id = 6, FirstName = "TATA", LastName = "Player", Address = "noIda", Email = "join@gmail.com", Phone = "12345678990" }
            };

            emp.ForEach(x => context.Employee.Add(x));
            context.SaveChanges();
        }
    }
}