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
    public class TicketStatusQuery : ITicketStatusQuery
    {
        private readonly AppDbContext _context;
        public TicketStatusQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<TicketStatus> GetListTicketsStatus()
        {
            var tickets = _context.TicketStatus.ToList();
            return tickets;
        }

        public TicketStatus getTicketStatus(int idTicket)
        {
            var ticket = _context.TicketStatus.FirstOrDefault(t => t.idStatus == idTicket);
            return ticket;
        }

        public TicketStatus UpdateTicketStatus(int idStatus, TicketStatusRequest ticketRequest)
        {
            var ticket = _context.TicketStatus.FirstOrDefault(t => t.idStatus == idStatus);
            if (ticket == null)
            {
                return null; ;
            }

            ticket.description = ticketRequest.description;
            _context.SaveChanges();

            return ticket;
        }

        public bool DeleteTicketStatus(int idStatus)
        {
            var ticket = _context.TicketStatus.FirstOrDefault(t => t.idStatus == idStatus);
            if (ticket == null)
            {
                return false;
            }
            _context.TicketStatus.Remove(ticket);
            _context.SaveChanges();
            return true;
        }
    }
}
