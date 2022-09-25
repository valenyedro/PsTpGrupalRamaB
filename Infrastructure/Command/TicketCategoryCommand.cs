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
    public class TicketCategoryCommand : ITicketCategoryCommand
    {
        private readonly AppDbContext _context;

        public TicketCategoryCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertTicketCategory(TicketCategory ticket)
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
