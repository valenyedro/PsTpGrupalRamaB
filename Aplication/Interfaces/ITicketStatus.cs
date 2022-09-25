using Aplication.Models;
using Aplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface ITicketStatus
    {
        Task<TicketStatusResponse> CreateTicket(TicketRequest request);
        Task<TicketStatusResponse> UpdateTicket(int idTicket, TicketRequest ticketRequest);
        Task<List<TicketStatusResponse>> GetAll();
        Task<TicketStatusResponse> getById(int idTicket);

        Task<bool> DeleteTicket(int idTicket);
    }
}
