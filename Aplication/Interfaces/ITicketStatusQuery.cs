using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface ITicketStatusQuery
    {
        List<TicketStatus> GetListTicketsStatus();
        TicketStatus getTicketStatus(int idStatus);
        TicketStatus UpdateTicketStatus(int idStatus, TicketStatusRequest ticketStatusRequest);
        bool DeleteTicketStatus(int idStatus);
    }
}
