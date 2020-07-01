using ConsServer.Mapper;
using ConsServer.Models;
using ConsServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsServer.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeRepository _repository;
        private readonly IEmployeeMapper _mapper;

        public EmployeeController()
        {
            _repository = new EmployeeRepository();
            _mapper = new EmployeeMapper();
        }

        [HttpGet]
        [Route("list")]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                Successful = true,
                Result = _mapper.MapToDTOList(_repository.GetAll())
            });
        }

        [HttpGet]
        [Route("list/{id}")]
        public HttpResponseMessage GetById(int Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                Sccessful = true,
                Result = _mapper.MapToDTO(_repository.GetSingle(Id))
            });
        }

        [HttpPost]
        [Route("add")]
        public async Task<HttpResponseMessage> AddAsync([FromBody] EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                Sccessful = true,
                Result = await _repository.AddAsync(_mapper.MapToEntity(employee))
            });
        }

        [HttpPut]
        [Route("edit")]
        public HttpResponseMessage UpdateAsync([FromBody] EmployeeDTO dTO)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            var emp = _mapper.MapToEntity(dTO);
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                Sccessful = true,
                Result =  _repository.Update(emp)
            });
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            var emp = _repository.GetSingle(id);
            if (emp == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "");
            }
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                Sccessful = true,
                Result = await _repository.DeleteAsync(id)
            });
        }
    }
}
