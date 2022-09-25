using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface ITicketBodyCommand
    {
        Task InsertTicketBody(TicketBody ticketBody);

        Task RemoveTicket(int idStatus);
    }
}
