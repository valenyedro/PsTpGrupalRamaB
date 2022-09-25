using Aplication.Interfaces.ITicketPriority;
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
    public class TicketPriorityQuery : ITicketPriorityQuery
    {
        private readonly AppDbContext _context;

        public TicketPriorityQuery(AppDbContext context)
        {
            _context = context;
        }

        public bool DeleteTicketPriority(int idTicketPriority)
        {
            var ticketPriority = _context.TicketPriority.FirstOrDefault(t => t.idPriority == idTicketPriority);
            if (ticketPriority == null)
            {
                return false;
            }
            _context.TicketPriority.Remove(ticketPriority);
            _context.SaveChanges();
            return true;
        }

        public List<TicketPriority> GetListTicketPriority()
        {
            var ticketPriority = _context.TicketPriority.ToList();
            return ticketPriority;
        }

        public TicketPriority getTicketPriority(int idTicketPriority)
        {
            var ticketPriority = _context.TicketPriority.FirstOrDefault(t => t.idPriority == idTicketPriority);
            return ticketPriority;
        }

        public TicketPriority UpdateTicketPriority(int idTicketPriority, TicketPriorityRequest ticketPriorityRequest)
        {
            var ticketPriority = _context.TicketPriority.FirstOrDefault(t => t.idPriority == idTicketPriority);
            if (ticketPriority == null)
            {
                return null; ;
            }
            ticketPriority.description = ticketPriorityRequest.description;
            _context.SaveChanges();
            return ticketPriority;
        }
    }
}
