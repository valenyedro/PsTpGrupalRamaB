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
    public class TicketCategoryQuery : ITicketCategoryQuery
    {
        private readonly AppDbContext _context;
        public TicketCategoryQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<TicketCategory> GetListTickets()
        {
            var tickets = _context.TicketCategory.ToList();
            return tickets;
        }

        public TicketCategory getTicket(int idTicket)
        {
            var ticket = _context.TicketCategory.FirstOrDefault(t => t.idCategory == idTicket);
            return ticket;
        }

        public TicketCategory UpdateTicket(int idTicket, TicketCategoryRequest ticketRequest)
        {
            var ticket = _context.TicketCategory.FirstOrDefault(t => t.idCategory == idTicket);
            if (ticket == null)
            {
                return null; ;
            }

            ticket.name = ticketRequest.name;
            ticket.description = ticketRequest.description;
            ticket.reqApproval = ticketRequest.reqApproval;
            ticket.dateCreate = ticketRequest.dateCreate;
            _context.SaveChanges();

            return ticket;
        }

        public bool DeleteTicket(int idTicket)
        {
            var ticket = _context.TicketCategory.FirstOrDefault(t => t.idCategory == idTicket);
            if (ticket == null)
            {
                return false;
            }
            _context.TicketCategory.Remove(ticket);
            _context.SaveChanges();
            return true;
        }
    }
}
