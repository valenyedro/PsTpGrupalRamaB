using Aplication.Interfaces;
using Aplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalStatusController : ControllerBase
    {
        private readonly IApprovalStatusService _services;

        public ApprovalStatusController(IApprovalStatusService services)
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
        public async Task<IActionResult> CreateApprovalStatus(ApprovalStatusRequest request)
        {
            var result = await _services.CreateApprovalStatus(request);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpPut("{idApprovalStatus}")]
        public async Task<IActionResult> UpdateApprovalStatus(int idApprovalStatus, ApprovalStatusRequest request)
        {
            try
            {
                var result = await _services.UpdateApprovalStatus(idApprovalStatus, request);

                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (NullReferenceException j)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }
        }

        [HttpGet("{idApprovalStatus}")]
        public async Task<IActionResult> GetById(int idApprovalStatus)
        {
            try
            {
                var result = await _services.getById(idApprovalStatus);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (NullReferenceException e)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }
        }

        [HttpDelete("{idApprovalStatus}")]
        public async Task<IActionResult> DeleteApprovalStatus(int idApprovalStatus)
        {
            try
            {
                var result = await _services.DeleteApprovalStatus(idApprovalStatus);
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
