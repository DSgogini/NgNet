using ConsServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsServer.Mapper
{
    public interface IEmployeeMapper
    {
        EmployeeDTO MapToDTO(EmployeeEntity entity);
        IList<EmployeeDTO> MapToDTOList(List<EmployeeEntity> entity);
        EmployeeEntity MapToEntity(EmployeeDTO dTO);
    }
}