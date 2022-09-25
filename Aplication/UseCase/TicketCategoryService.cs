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
    public class TicketCategoryService : ITicketCategoryService
    {
        private readonly ITicketCategoryCommand _command;
        private readonly ITicketCategoryQuery _query;

        public TicketCategoryService(ITicketCategoryCommand command, ITicketCategoryQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<TicketCategoryResponse> CreateTicketCategory(TicketCategoryRequest request)
        {
            var ticket = new TicketCategory
            {
                name = request.name,
                description = request.description,
                reqApproval = request.reqApproval,
                dateCreate = request.dateCreate
            };

            await _command.InsertTicketCategory(ticket);
            return new TicketCategoryResponse
            {
                name = request.name,
                description = request.description,
                reqApproval = request.reqApproval,
                dateCreate = request.dateCreate
            };
        }

        public async Task<bool> DeleteTicketCategory(int idCategory)
        {
            return await Task.FromResult(_query.DeleteTicket(idCategory));
        }

        public Task<List<TicketCategoryResponse>> GetAll()
        {
            var tickets = _query.GetListTickets();
            List<TicketCategoryResponse> result = new List<TicketCategoryResponse>();

            foreach (TicketCategory ticket in tickets)
            {
                var ticketCategoryResponse = new TicketCategoryResponse
                {
                    idCategory = ticket.idCategory,
                    name = ticket.name,
                    description = ticket.description,
                    reqApproval = ticket.reqApproval,
                    dateCreate = ticket.dateCreate
                };

                result.Add(ticketCategoryResponse);
            }
            return Task.FromResult(result);
        }

        public Task<TicketCategoryResponse> getById(int idTicket)
        {
            var ticket = _query.getTicket(idTicket);
            if (ticket == null)
            {
                return null;
            }
            return Task.FromResult(new TicketCategoryResponse
            {
                idCategory = ticket.idCategory,
                name = ticket.name,
                description = ticket.description,
                reqApproval = ticket.reqApproval,
                dateCreate = ticket.dateCreate
            });
        }

        Task<TicketCategoryResponse> ITicketCategoryService.UpdateTicketCategory(int idTicket, TicketCategoryRequest ticketRequest)
        {

            var ticket = _query.UpdateTicket(idTicket, ticketRequest);
            if (ticket == null)
            {
                return null;
            }
            return Task.FromResult(new TicketCategoryResponse
            {
                idCategory = ticket.idCategory,
                name = ticket.name,
                description = ticket.description,
                reqApproval = ticket.reqApproval,
                dateCreate = ticket.dateCreate
            });
        }
    }
}
