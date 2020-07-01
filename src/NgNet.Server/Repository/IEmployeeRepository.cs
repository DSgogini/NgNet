using ConsServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsServer.Repository
{
    public interface IEmployeeRepository
    {
        List<EmployeeEntity> GetAll();
        EmployeeEntity GetSingle(int id);
        Task<int> AddAsync(EmployeeEntity entity);
        Task<int> UpdateAsync(EmployeeEntity entity);
        int Update(EmployeeEntity entity);
        Task<int> DeleteAsync(int id);
    }
}
