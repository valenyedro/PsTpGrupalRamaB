using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicketPriority
{
    public interface ITicketPriorityCommand
    {
        Task InsertTicketPriority(TicketPriority ticketPriority);

        Task RemoveTicketPriority(int idTicketPriority);
    }
}
