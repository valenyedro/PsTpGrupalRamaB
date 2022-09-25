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
    public class TicketStatusService : ITicketStatusService
    {
        private readonly ITicketStatusCommand _command;
        private readonly ITicketStatusQuery _query;

        public TicketStatusService(ITicketStatusCommand command, ITicketStatusQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<TicketStatusResponse> CreateTicketStatus(TicketStatusRequest request)
        {
            var ticketStatus = new TicketStatus
            {
                description = request.description
            };

            await _command.InsertTicketStatus(ticketStatus);
            return new TicketStatusResponse
            {
                description = request.description,
            };
        }

        public async Task<bool> DeleteTicketStatus(int idStatus)
        {
            return await Task.FromResult(_query.DeleteTicketStatus(idStatus));
        }

        public Task<List<TicketStatusResponse>> GetAll()
        {
            var tickets = _query.GetListTicketsStatus();
            List<TicketStatusResponse> result = new List<TicketStatusResponse>();

            foreach (TicketStatus ticket in tickets)
            {
                var ticketResponse = new TicketStatusResponse
                {
                    idStatus = ticket.idStatus,
                    description = ticket.description
                };

                result.Add(ticketResponse);
            }
            return Task.FromResult(result);
        }

        public Task<TicketStatusResponse> getById(int idStatus)
        {
            var ticket = _query.getTicketStatus(idStatus);
            if (ticket == null)
            {
                return null;
            }
            return Task.FromResult(new TicketStatusResponse
            {
                idStatus = ticket.idStatus,
                description = ticket.description
            });
        }


        Task<TicketStatusResponse> ITicketStatusService.UpdateTicketStatus(int idStatus, TicketStatusRequest ticketRequest)
        {
            var ticket = _query.UpdateTicketStatus(idStatus, ticketRequest);
            if (ticket == null)
            {
                return null;
            }
            return Task.FromResult(new TicketStatusResponse
            {
                description = ticket.description
            });
        }
    }
}
