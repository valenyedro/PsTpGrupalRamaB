using Aplication.Interfaces;
using Aplication.Models;
using Aplication.Response;
using Domain.Entities;

namespace Aplication.UseCase
{
    public class TicketService : ITicketService
    {

        private readonly ITicketCommand _command;
        private readonly ITicketQuery _query;

        public TicketService(ITicketCommand command, ITicketQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<TicketResponse> CreateTicket(TicketRequest request)
        {
            var ticket = new Ticket
            {
                idUser = request.idUser,
                idStatus = request.idStatus,
                idExecutionStatus = request.idExecutionStatus,
                idPriority = request.idPriority,
                idCategory = request.idCategory,
                idUserExecutor = request.idUserExecutor,
                idApprovalStatus = request.idApprovalStatus,
                idTicketBody = request.idTicketBody,
                minApproveReq = request.minApproveReq,
                countOpen = request.countOpen,
                countDisapproved = request.countDisapproved,
                countApproved = request.countApproved
            };

            await _command.InsertTicket(ticket);
            return new TicketResponse
            {
                idUser = request.idUser,
                idStatus = request.idStatus,
                idExecutionStatus = request.idExecutionStatus,
                idPriority = request.idPriority,
                idCategory = request.idCategory,
                idUserExecutor = request.idUserExecutor,
                idApprovalStatus = request.idApprovalStatus,
                idTicketBody = request.idTicketBody,
                minApproveReq = request.minApproveReq,
                countOpen = request.countOpen,
                countDisapproved = request.countDisapproved,
                countApproved = request.countApproved
            };
        }

        public async Task<bool> DeleteTicket(int idTicket)
        {
            return await Task.FromResult(_query.DeleteTicket(idTicket));
        }

        public Task<List<TicketResponse>> GetAll()
        {
            var tickets = _query.GetListTickets();
            List<TicketResponse> result = new List<TicketResponse>();

            foreach (Ticket ticket in tickets)
            {
                var ticketResponse = new TicketResponse
                {
                    idTicket = ticket.idTicket,
                    idUser = ticket.idUser,
                    idStatus = ticket.idStatus,
                    idExecutionStatus = ticket.idExecutionStatus,
                    idPriority = ticket.idPriority,
                    idCategory = ticket.idCategory,
                    idUserExecutor = ticket.idUserExecutor,
                    idApprovalStatus = ticket.idApprovalStatus,
                    idTicketBody = ticket.idTicketBody,
                    minApproveReq = ticket.minApproveReq,
                    countOpen = ticket.countOpen,
                    countDisapproved = ticket.countDisapproved,
                    countApproved = ticket.countApproved
                };
                
                result.Add(ticketResponse);
            }
            return Task.FromResult(result); 
        }

        public Task<TicketResponse>getById(int idTicket)
        {
            var ticket = _query.getTicket(idTicket);
            if(ticket == null)
            {
                return null;
            }
            return Task.FromResult(new TicketResponse
            {
                idTicket = ticket.idTicket,
                idUser = ticket.idUser,
                idStatus = ticket.idStatus,
                idExecutionStatus = ticket.idExecutionStatus,
                idPriority = ticket.idPriority,
                idCategory = ticket.idCategory,
                idUserExecutor = ticket.idUserExecutor,
                idApprovalStatus = ticket.idApprovalStatus,
                idTicketBody = ticket.idTicketBody,
                minApproveReq = ticket.minApproveReq,
                countOpen = ticket.countOpen,
                countDisapproved = ticket.countDisapproved,
                countApproved = ticket.countApproved
            });
        }

        Task<TicketResponse> ITicketService.UpdateTicket(int idTicket, TicketRequest ticketRequest)
        {
            
            var ticket = _query.UpdateTicket(idTicket, ticketRequest);
            if (ticket == null)
            {
                return null;
            }
            return Task.FromResult(new TicketResponse
            {
                idTicket = ticket.idTicket,
                idUser = ticket.idUser,
                idStatus = ticket.idStatus,
                idExecutionStatus = ticket.idExecutionStatus,
                idPriority = ticket.idPriority,
                idCategory = ticket.idCategory,
                idUserExecutor = ticket.idUserExecutor,
                idApprovalStatus = ticket.idApprovalStatus,
                idTicketBody = ticket.idTicketBody,
                minApproveReq = ticket.minApproveReq,
                countOpen = ticket.countOpen,
                countDisapproved = ticket.countDisapproved,
                countApproved = ticket.countApproved
            });
        }
    }
}
