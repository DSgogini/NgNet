using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NgNet.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NgNet.Application.Employees.Queries
{
    public class GetEmployeeListQuery : IRequest<EmployeesListVm>
    {
    }

    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeeListQuery, EmployeesListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetEmployeesListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeesListVm> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employee.ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                .OrderBy(e => e.Name).ToListAsync();

            return new EmployeesListVm
            {
                Employees = employees
            };
        }
    }

}
