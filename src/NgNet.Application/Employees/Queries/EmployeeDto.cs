using AutoMapper;
using NgNet.Application.Common.Mappings;
using NgNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgNet.Application.Employees.Queries
{
    public class EmployeeDto: IMapFrom<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.EmployeeId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.LastName + ", " + s.FirstName))
                .ForMember(d => d.Designation, opt => opt.MapFrom(s => s.Title));
        }
    }
}
