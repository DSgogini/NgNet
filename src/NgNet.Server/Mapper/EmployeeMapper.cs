using ConsServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsServer.Mapper
{
    public class EmployeeMapper:IEmployeeMapper
    {
        public EmployeeDTO MapToDTO(EmployeeEntity entity)
        {
            return new EmployeeDTO()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Phone = entity.Phone,
                Address = entity.Address
            };
        }

        public IList<EmployeeDTO> MapToDTOList(List<EmployeeEntity> entity)
        {
            IList<EmployeeDTO> list = new List<EmployeeDTO>();
            foreach (var item in entity)
            {
                var emp = new EmployeeDTO()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Phone = item.Phone,
                    Address = item.Address
                };
                list.Add(emp);
            }
            return list;
        }

        public EmployeeEntity MapToEntity(EmployeeDTO entity)
        {
            return new EmployeeEntity()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Phone = entity.Phone,
                Address = entity.Address
            };
        }
    }
}