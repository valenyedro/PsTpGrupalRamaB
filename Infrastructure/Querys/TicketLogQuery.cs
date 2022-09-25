using Aplication.Interfaces.ITicketLog;
using Aplication.Models;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class TicketLogQuery :ITicketLogQuery
    {
        private readonly AppDbContext _context;

        public TicketLogQuery(AppDbContext context)
        {
            _context = context;
        }

        public bool DeleteTicketLog(int idTicketLog)
        {
            var ticketLog = _context.TicketLogs.FirstOrDefault(t => t.idTicketLog == idTicketLog);
            if (ticketLog == null)
            {
                return false;
            }
            _context.TicketLogs.Remove(ticketLog);
            _context.SaveChanges();
            return true;
        }

        public List<TicketLog> GetListTicketLogs()
        {
            var ticketLogs = _context.TicketLogs.ToList();
            return ticketLogs;
        }

        public TicketLog getTicketLog(int idTicketLog)
        {
            var ticketLog = _context.TicketLogs.FirstOrDefault(t => t.idTicketLog == idTicketLog);
            return ticketLog;
        }

        public TicketLog UpdateTicketLog(int idTicketLog, TicketLogRequest ticketLogRequest)
        {
            var ticketLog = _context.TicketLogs.FirstOrDefault(t => t.idTicketLog == idTicketLog);
            if (ticketLog == null)
            {
                return null; ;
            }

            ticketLog.idTicket = ticketLogRequest.idTicket;
            ticketLog.idUser = ticketLogRequest.idUser;
            ticketLog.idUserCategory = ticketLogRequest.idUserCategory;
            ticketLog.dateHistory = ticketLogRequest.dateHistory;
            ticketLog.idAction = ticketLogRequest.idAction;
            _context.SaveChanges();

            return ticketLog;
        }
    }
}
