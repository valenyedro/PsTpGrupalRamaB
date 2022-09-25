using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicketPriority
{
    public interface ITicketPriorityService
    {
        Task<TicketPriorityResponse> CreateTicketPriority(TicketPriorityRequest request);
        Task<TicketPriorityResponse> UpdateTicketPriority(int idTicketPriority, TicketPriorityRequest ticketPriorityRequest);
        Task<List<TicketPriorityResponse>> GetAll();
        Task<TicketPriorityResponse> getById(int idTicketPriority);

        Task<bool> DeleteTicketPriority(int idTicketPriority);
    }
}
