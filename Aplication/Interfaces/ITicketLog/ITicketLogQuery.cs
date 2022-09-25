using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicketLog
{
    public interface ITicketLogQuery
    {
        List<TicketLog> GetListTicketLogs();
        TicketLog getTicketLog(int idTicketLog);
        TicketLog UpdateTicketLog(int idTicketLog, TicketLogRequest ticketLogRequest);
        bool DeleteTicketLog(int idTicketLog);
    }
}
