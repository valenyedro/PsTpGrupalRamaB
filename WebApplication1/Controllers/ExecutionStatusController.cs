using Aplication.Interfaces;
using Aplication.Interfaces.IExecutionStatus;
using Aplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutionStatusController : ControllerBase
    {
        private readonly IExecutionStatusServices _services;

        public ExecutionStatusController(IExecutionStatusServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExecutionStatus(ExecutionStatusRequest request)
        {
            var result = await _services.CreateExecutionStatus(request);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpPut("{idExecutionStatus}")]
        public async Task<IActionResult> UpdateExecutionStatus(int idExecutionStatus, ExecutionStatusRequest request)
        {
            try
            {
                var result = await _services.UpdateExecutionStatus(idExecutionStatus, request);

                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (NullReferenceException j)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }
        }

        [HttpGet("{idExecutionStatus}")]
        public async Task<IActionResult> GetById(int idExecutionStatus)
        {
            try
            {
                var result = await _services.getById(idExecutionStatus);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (NullReferenceException e)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }
        }

        [HttpDelete("{idExecutionStatus}")]
        public async Task<IActionResult> DeleteExecutionStatus(int idExecutionStatus)
        {
            try
            {
                var result = await _services.DeleteExecutionStatus(idExecutionStatus);
                if (result == true)
                {
                    return new JsonResult(result) { StatusCode = 202 };
                }
                return NotFound();
            }
            catch (NullReferenceException e)
            {
                return NotFound();
            }
        }
    }
}
