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
    public class TicketStatusCommand : ITicketStatusCommand
    {
        private readonly AppDbContext _context;

        public TicketStatusCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertTicketStatus(TicketStatus ticket)
        {
            _context.Add(ticket);
            await _context.SaveChangesAsync();

        }

        public Task RemoveTicketStatus(int idStatus)
        {
            throw new NotImplementedException();
        }
    }
}
