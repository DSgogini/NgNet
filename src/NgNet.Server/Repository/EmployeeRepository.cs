using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsServer.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsServer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<int> AddAsync(EmployeeEntity entity)
        {
            _context.Employee.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var emp = GetSingle(id);
            _context.Employee.Remove(emp);
            return await _context.SaveChangesAsync();
        }

        public List<EmployeeEntity> GetAll()
        {
            return _context.Employee.OrderByDescending(x => x.DateUpdated).ToList();
        }

        public EmployeeEntity GetSingle(int id)
        {
            return _context.Employee.FirstOrDefault(x => x.Id == id);
        }

        public int Update(EmployeeEntity entity)
        {
            EmployeeEntity emp = GetSingle(entity.Id);
            if (emp == null)
            {
                return 0;
            }
            _context.Entry(emp).CurrentValues.SetValues(entity);
            return _context.SaveChanges();
        }

        public Task<int> UpdateAsync(EmployeeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}