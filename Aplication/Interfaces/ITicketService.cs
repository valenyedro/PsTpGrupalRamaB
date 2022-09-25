using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface ITicketService
    {
        Task<TicketResponse> CreateTicket(TicketRequest request);
        Task<TicketResponse> UpdateTicket(int idTicket, TicketRequest ticketRequest);
        Task<List<TicketResponse>> GetAll();
        Task<TicketResponse> getById(int idTicket);

        Task<bool> DeleteTicket(int idTicket);


    }
}
