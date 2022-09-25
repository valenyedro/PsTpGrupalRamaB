using Aplication.Interfaces;
using Aplication.Interfaces.ITicketPriority;
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
    public class TicketPriorityService : ITicketPriorityService
    {
        private readonly ITicketPriorityCommand _command;
        private readonly ITicketPriorityQuery _query;

        public TicketPriorityService(ITicketPriorityCommand command, ITicketPriorityQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<TicketPriorityResponse> CreateTicketPriority(TicketPriorityRequest request)
        {
            var ticketPriority = new TicketPriority
            {
                description = request.description,
            };

            await _command.InsertTicketPriority(ticketPriority);
            return new TicketPriorityResponse
            {
                description = request.description,
            };
        }

        public async Task<bool> DeleteTicketPriority(int idTicketPriority)
        {
            return await Task.FromResult(_query.DeleteTicketPriority(idTicketPriority));
        }

        public Task<List<TicketPriorityResponse>> GetAll()
        {
            var ticketPrioritys = _query.GetListTicketPriority();
            List<TicketPriorityResponse> result = new List<TicketPriorityResponse>();

            foreach (TicketPriority ticketPriority in ticketPrioritys)
            {
                var ticketPriorityResponse = new TicketPriorityResponse
                {
                    idPriority = ticketPriority.idPriority,
                    description = ticketPriority.description,
                };

                result.Add(ticketPriorityResponse);
            }
            return Task.FromResult(result);
        }

        public Task<TicketPriorityResponse> getById(int idTicketPriority)
        {
            var ticketPriority = _query.getTicketPriority(idTicketPriority);
            if (ticketPriority == null)
            {
                return null;
            }
            return Task.FromResult(new TicketPriorityResponse
            {
                idPriority = ticketPriority.idPriority,
                description = ticketPriority.description,
            });
        }

        public Task<TicketPriorityResponse> UpdateTicketPriority(int idTicketPriority, TicketPriorityRequest ticketPriorityRequest)
        {
            var ticketPriority = _query.UpdateTicketPriority(idTicketPriority, ticketPriorityRequest);
            if (ticketPriority == null)
            {
                return null;
            }
            return Task.FromResult(new TicketPriorityResponse
            {
                idPriority = ticketPriority.idPriority,
                description = ticketPriority.description,
            });
        }
    }
}
