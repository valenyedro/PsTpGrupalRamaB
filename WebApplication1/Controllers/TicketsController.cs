using Aplication.Interfaces;
using Aplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _services;

        public TicketsController(ITicketService services)
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
        public async Task<IActionResult> CreateTicket(TicketRequest request)
        {
            var result = await _services.CreateTicket(request);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpPut("{idTicket}")]
        public async Task<IActionResult> UpdateTicket(int idTicket, TicketRequest request)
        {
            try
            {
                var result = await _services.UpdateTicket(idTicket, request);
            
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (NullReferenceException j)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }
        }

        [HttpGet("{idTicket}")]
        public async Task<IActionResult> GetById(int idTicket)
        {   
            try
            {
                var result = await _services.getById(idTicket);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch(NullReferenceException e)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }
        }

        [HttpDelete("{idTicket}")]
        public async Task<IActionResult> DeleteTicket(int idTicket)
        {
            
            try
            {
                var result = await _services.DeleteTicket(idTicket);
                if(result == true)
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
