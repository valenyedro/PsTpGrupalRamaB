using Aplication.Interfaces;
using Aplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketStatusController : ControllerBase
    {
        private readonly ITicketStatusService _services;

        public TicketStatusController(ITicketStatusService services)
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
        public async Task<IActionResult> CreateTicket(TicketStatusRequest request)
        {
            var result = await _services.CreateTicketStatus(request);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpPut("{idStatus}")]
        public async Task<IActionResult> UpdateTicket(int idStatus, TicketStatusRequest request)
        {
            try
            {
                var result = await _services.UpdateTicketStatus(idStatus, request);

                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (NullReferenceException j)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }
        }

        [HttpGet("{idStatus}")]
        public async Task<IActionResult> GetById(int idTicket)
        {
            try
            {
                var result = await _services.getById(idTicket);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (NullReferenceException e)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }
        }

        [HttpDelete("{idStatus}")]
        public async Task<IActionResult> DeleteTicket(int idStatus)
        {

            try
            {
                var result = await _services.DeleteTicketStatus(idStatus);
                if (result == true)
                {
                    return new JsonResult(result) { StatusCode = 202 };
                }
                return NotFound();
            }
            catch (NullReferenceException e)
            {
                return NotFound();
                //return new JsonResult(null) { StatusCode = 404 };
            }
        }
    }
}
