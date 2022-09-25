using Aplication.Interfaces.ITicketLog;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class TicketLogCommand : ITicketLogCommand
    {
        private readonly AppDbContext _context;

        public TicketLogCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertTicketLog(TicketLog ticketLog)
        {
            _context.Add(ticketLog);
            await _context.SaveChangesAsync();
        }

        public Task RemoveTicketLog(int idTicketLog)
        {
            throw new NotImplementedException();
        }
    }
}
