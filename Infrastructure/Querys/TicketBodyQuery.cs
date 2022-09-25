using Aplication.Interfaces;
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
    public class TicketBodyQuery : ITicketBodyQuery
    {
        private readonly AppDbContext _context;
        public TicketBodyQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<TicketBody> GetListTickets()
        {
            var tickets = _context.TicketBody.ToList();
            return tickets;
        }

        public TicketBody getTicket(int idTicket)
        {
            var ticket = _context.TicketBody.FirstOrDefault(t => t.idTicketBody == idTicket);
            return ticket;
        }

        public TicketBody UpdateTicket(int idTicket, TicketBodyRequest ticketRequest)
        {
            var ticket = _context.TicketBody.FirstOrDefault(t => t.idTicketBody == idTicket);
            if (ticket == null)
            {
                return null; ;
            }

            ticket.title = ticketRequest.title;
            ticket.description = ticketRequest.description;
            ticket.file = ticketRequest.file;
            _context.SaveChanges();

            return ticket;
        }

        public bool DeleteTicket(int idTicket)
        {
            var ticket = _context.TicketBody.FirstOrDefault(t => t.idTicketBody == idTicket);
            if (ticket == null)
            {
                return false;
            }
            _context.TicketBody.Remove(ticket);
            _context.SaveChanges();
            return true;
        }
    }
}
