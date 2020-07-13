using MediatR;
using NgNet.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NgNet.Application.Employees.Commands
{
    public class SaveEmployeeCommand : IRequest<int>
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Designation { get; set; }
        public string Extension { get; set; }
        public DateTime? HireDate { get; set; }
        public string Notes { get; set; }
        public byte[] Photo { get; set; }
        public int? ManagerId { get; set; }
    }

    public class SaveEmployeeCommandHandler : IRequestHandler<SaveEmployeeCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public SaveEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(SaveEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}