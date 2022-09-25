using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface ITicketCategoryQuery
    {
        List<TicketCategory> GetListTickets();
        TicketCategory getTicket(int idTicket);
        TicketCategory UpdateTicket(int idTicket, TicketCategoryRequest ticketRequest);
        bool DeleteTicket(int idTicket);
    }
}
