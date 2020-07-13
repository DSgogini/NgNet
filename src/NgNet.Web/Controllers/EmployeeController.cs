using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NgNet.Application.Employees.Queries;

namespace NgNet.Web.Controllers
{
    [Authorize]
    public class EmployeeController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<EmployeesListVm>> Get()
        {
            return await Mediator.Send(new GetEmployeeListQuery());
        }

    }
}