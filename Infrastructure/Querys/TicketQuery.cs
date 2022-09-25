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
    public class TicketQuery : ITicketQuery
    {
        private readonly AppDbContext _context;
        public TicketQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<Ticket> GetListTickets()
        {
            var tickets = _context.Ticket.ToList();
            return tickets;
        }

        public Ticket getTicket(int idTicket)
        {
            var ticket = _context.Ticket.FirstOrDefault(t => t.idTicket == idTicket);
            return ticket;
        }

        public Ticket UpdateTicket(int idTicket, TicketRequest ticketRequest)
        {
            var ticket = _context.Ticket.FirstOrDefault(t => t.idTicket == idTicket);
            if(ticket == null)
            {
                return null; ;
            }

            ticket.idUser = ticketRequest.idUser;
            ticket.idStatus = ticketRequest.idStatus;
            ticket.idExecutionStatus = ticketRequest.idExecutionStatus;
            ticket.idPriority = ticketRequest.idPriority;
            ticket.idCategory = ticketRequest.idCategory;
            ticket.idUserExecutor = ticketRequest.idUserExecutor;
            ticket.idApprovalStatus = ticketRequest.idApprovalStatus;
            ticket.idTicketBody = ticketRequest.idTicketBody;
            ticket.minApproveReq = ticketRequest.minApproveReq;
            ticket.countOpen = ticketRequest.countOpen;
            ticket.countDisapproved = ticketRequest.countDisapproved;
            ticket.countApproved = ticketRequest.countApproved;
            _context.SaveChanges();
          
            return ticket;
        }

        public bool DeleteTicket(int idTicket)
        {
            var ticket = _context.Ticket.FirstOrDefault(t => t.idTicket == idTicket);
            if(ticket == null)
            {
                return false;
            }
            _context.Ticket.Remove(ticket);
            _context.SaveChanges();
            return true;
        }
    }
}
