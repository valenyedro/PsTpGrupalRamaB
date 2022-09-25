using Aplication.Models;
using Aplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface ITicketStatusService
    {
        Task<TicketStatusResponse> CreateTicketStatus(TicketStatusRequest request);
        Task<TicketStatusResponse> UpdateTicketStatus(int idStatus, TicketStatusRequest ticketStatusRequest);
        Task<List<TicketStatusResponse>> GetAll();
        Task<TicketStatusResponse> getById(int idStatus);

        Task<bool> DeleteTicketStatus(int idTicket);
    }
}
