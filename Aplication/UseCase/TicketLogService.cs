using Aplication.Interfaces;
using Aplication.Interfaces.ITicketLog;
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
    public class TicketLogService : ITicketLogService
    {
        private readonly ITicketLogCommand _command;
        private readonly ITicketLogQuery _query;

        public TicketLogService(ITicketLogCommand command, ITicketLogQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<TicketLogResponse> CreateTicketLog(TicketLogRequest request)
        {
            var ticketLog = new TicketLog
            {
                idTicket = request.idTicket,
                idUser = request.idUser,
                idUserCategory = request.idUserCategory,
                dateHistory = request.dateHistory,
                idAction = request.idAction,
            };

            await _command.InsertTicketLog(ticketLog);
            return new TicketLogResponse
            {
                idTicket = request.idTicket,
                idUser = request.idUser,
                idUserCategory = request.idUserCategory,
                dateHistory = request.dateHistory,
                idAction = request.idAction,
            };
        }

        public async Task<bool> DeleteTicketLog(int idTicketLog)
        {
            return await Task.FromResult(_query.DeleteTicketLog(idTicketLog));
        }

        public Task<List<TicketLogResponse>> GetAll()
        {
            var ticketLogs = _query.GetListTicketLogs();
            List<TicketLogResponse> result = new List<TicketLogResponse>();

            foreach (TicketLog ticketLog in ticketLogs)
            {
                var ticketLogResponse = new TicketLogResponse
                {
                    idTicketLog = ticketLog.idTicketLog,
                    idTicket = ticketLog.idTicket,
                    idUser = ticketLog.idUser,
                    idUserCategory = ticketLog.idUserCategory,
                    dateHistory = ticketLog.dateHistory,
                    idAction = ticketLog.idAction,
                };
                result.Add(ticketLogResponse);
            }
            return Task.FromResult(result);
    }

        public Task<TicketLogResponse> getById(int idTicketLog)
        {
            var ticketLog = _query.getTicketLog(idTicketLog);
            if (ticketLog == null)
            {
                return null;
            }
            return Task.FromResult(new TicketLogResponse
            {
                idTicketLog = ticketLog.idTicketLog,
                idTicket = ticketLog.idTicket,
                idUser = ticketLog.idUser,
                idUserCategory = ticketLog.idUserCategory,
                dateHistory = ticketLog.dateHistory,
                idAction = ticketLog.idAction,
            });
        }

        public Task<TicketLogResponse> UpdateTicketLog(int idTicketLog, TicketLogRequest ticketLogRequest)
        {
            var ticketLog = _query.UpdateTicketLog(idTicketLog, ticketLogRequest);
            if (ticketLog == null)
            {
                return null;
            }
            return Task.FromResult(new TicketLogResponse
            {
                idTicketLog = ticketLog.idTicketLog,
                idTicket = ticketLog.idTicket,
                idUser = ticketLog.idUser,
                idUserCategory = ticketLog.idUserCategory,
                dateHistory = ticketLog.dateHistory,
                idAction = ticketLog.idAction,
            });
        }
    }
}
