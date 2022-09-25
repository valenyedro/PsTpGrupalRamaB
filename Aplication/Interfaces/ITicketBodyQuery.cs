using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface ITicketBodyQuery
    {
        List<TicketBody> GetListTickets();
        TicketBody getTicket(int idTicket);
        TicketBody UpdateTicket(int idTicket, TicketBodyRequest ticketRequest);
        bool DeleteTicket(int idTicket);
    }
}
