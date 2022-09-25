using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicketPriority
{
    public interface ITicketPriorityQuery
    {
        List<TicketPriority> GetListTicketPriority();
        TicketPriority getTicketPriority(int idTicketPriority);
        TicketPriority UpdateTicketPriority(int idTicketPriority, TicketPriorityRequest ticketPriorityRequest);
        bool DeleteTicketPriority(int idTicketPriority);
    }
}
