using Aplication.Interfaces;
using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class TicketBodyService : ITicketBodyService
    {
        private readonly ITicketBodyCommand _command;
        private readonly ITicketBodyQuery _query;

        public TicketBodyService(ITicketBodyCommand command, ITicketBodyQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<TicketBodyResponse> CreateTicket(TicketBodyRequest request)
        {
            var ticket = new TicketBody
            {
                title = request.title,
                description = request.description,
                file = request.file
            };

            await _command.InsertTicketBody(ticket);
            return new TicketBodyResponse
            {
                title = request.title,
                description = request.description,
                file = request.file
            };
        }

        public async Task<bool> DeleteTicket(int idTicket)
        {
            return await Task.FromResult(_query.DeleteTicket(idTicket));
        }

        public Task<List<TicketBodyResponse>> GetAll()
        {
            var tickets = _query.GetListTickets();
            List<TicketBodyResponse> result = new List<TicketBodyResponse>();

            foreach (TicketBody ticket in tickets)
            {
                var ticketBodyResponse = new TicketBodyResponse
                {
                    idTicketBody = ticket.idTicketBody,
                    title = ticket.title,
                    description = ticket.description,
                    file = ticket.file
                };

                result.Add(ticketBodyResponse);
            }
            return Task.FromResult(result);
        }

        public Task<TicketBodyResponse> getById(int idTicket)
        {
            var ticket = _query.getTicket(idTicket);
            if (ticket == null)
            {
                return null;
            }
            return Task.FromResult(new TicketBodyResponse
            {
                idTicketBody = ticket.idTicketBody,
                title = ticket.title,
                description = ticket.description,
                file = ticket.file
            });
        }

        Task<TicketBodyResponse> ITicketBodyService.UpdateTicket(int idTicket, TicketBodyRequest ticketRequest)
        {

            var ticket = _query.UpdateTicket(idTicket, ticketRequest);
            if (ticket == null)
            {
                return null;
            }
            return Task.FromResult(new TicketBodyResponse
            {
                idTicketBody = ticket.idTicketBody,
                title = ticket.title,
                description = ticket.description,
                file = ticket.file
            });
        }
    }
}
