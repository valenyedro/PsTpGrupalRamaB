using Aplication.Interfaces;
using Aplication.Interfaces.ITicketPriority;
using Aplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketPriorityController : ControllerBase
    {
        private readonly ITicketPriorityService _services;

        public TicketPriorityController(ITicketPriorityService services)
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
        public async Task<IActionResult> CreateTicketPriority(TicketPriorityRequest request)
        {
            var result = await _services.CreateTicketPriority(request);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpPut("{idTicketPriority}")]
        public async Task<IActionResult> UpdateTicketPriority(int idTicketPriority, TicketPriorityRequest request)
        {
            try
            {
                var result = await _services.UpdateTicketPriority(idTicketPriority, request);

                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (NullReferenceException j)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }
        }

        [HttpGet("{idTicketPriority}")]
        public async Task<IActionResult> GetById(int idTicketPriority)
        {
            try
            {
                var result = await _services.getById(idTicketPriority);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (NullReferenceException e)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }
        }

        [HttpDelete("{idTicketPriority}")]
        public async Task<IActionResult> DeleteTicketPriority(int idTicketPriority)
        {
            try
            {
                var result = await _services.DeleteTicketPriority(idTicketPriority);
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
