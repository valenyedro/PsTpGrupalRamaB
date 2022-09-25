using Aplication.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class TicketBodyCommand : ITicketBodyCommand
    {
        private readonly AppDbContext _context;

        public TicketBodyCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertTicketBody(TicketBody ticket)
        {
            _context.Add(ticket);
            await _context.SaveChangesAsync();

        }

        public Task RemoveTicket(int idTicket)
        {
            throw new NotImplementedException();
        }
    }
}
