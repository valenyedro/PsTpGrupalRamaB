using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicketLog
{
    public interface ITicketLogCommand
    {
        Task InsertTicketLog(TicketLog ticketLog);

        Task RemoveTicketLog(int idTicketLog);
    }
}
