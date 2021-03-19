using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NgNet.Application.Employees.Commands;
using NgNet.Application.Employees.Queries;

namespace NgNet.Web.Controllers
{
    public class EmployeeController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<EmployeesListVm>> Get()
        {
            return await Mediator.Send(new GetEmployeeListQuery());
        }

        [Route("add")]
        public async Task<IActionResult> Save(SaveEmployeeCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
    }
}