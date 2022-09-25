using Aplication.Models;
using Aplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface ITicketBodyService
    {
        Task<TicketBodyResponse> CreateTicket(TicketBodyRequest request);
        Task<TicketBodyResponse> UpdateTicket(int idTicket, TicketBodyRequest ticketRequest);
        Task<List<TicketBodyResponse>> GetAll();
        Task<TicketBodyResponse> getById(int idTicket);

        Task<bool> DeleteTicket(int idTicket);
    }
}
