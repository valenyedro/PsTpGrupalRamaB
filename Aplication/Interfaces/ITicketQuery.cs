using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface ITicketQuery
    {
        List<Ticket> GetListTickets();
        Ticket getTicket(int idTicket);
        Ticket UpdateTicket(int idTicket, TicketRequest ticketRequest);
        bool DeleteTicket(int idTicket);

    }
}
