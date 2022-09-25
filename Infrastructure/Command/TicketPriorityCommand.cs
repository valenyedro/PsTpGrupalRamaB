using Aplication.Interfaces.ITicketPriority;
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
    public class TicketPriorityCommand : ITicketPriorityCommand
    {
        private readonly AppDbContext _context;

        public TicketPriorityCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertTicketPriority(TicketPriority ticketPriority)
        {
            _context.Add(ticketPriority);
            await _context.SaveChangesAsync();
        }

        public Task RemoveTicketPriority(int idTicketPriority)
        {
            throw new NotImplementedException();
        }
    }
}
