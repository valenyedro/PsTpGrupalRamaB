using Aplication.Interfaces;
using Aplication.Interfaces.ITicketLog;
using Aplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketLogController : ControllerBase
    {
        private readonly ITicketLogService _services;

        public TicketLogController(ITicketLogService services)
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
        public async Task<IActionResult> CreateTicketLog(TicketLogRequest request)
        {
            var result = await _services.CreateTicketLog(request);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpPut("{idTicketLog}")]
        public async Task<IActionResult> UpdateTicketLog(int idTicketLog, TicketLogRequest request)
        {
            try
            {
                var result = await _services.UpdateTicketLog(idTicketLog, request);

                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (NullReferenceException j)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }
        }

        [HttpGet("{idTicketLog}")]
        public async Task<IActionResult> GetById(int idTicketLog)
        {
            try
            {
                var result = await _services.getById(idTicketLog);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (NullReferenceException e)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }
        }

        [HttpDelete("{idTicketLog}")]
        public async Task<IActionResult> DeleteTicketLog(int idTicketLog)
        {
            try
            {
                var result = await _services.DeleteTicketLog(idTicketLog);
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
