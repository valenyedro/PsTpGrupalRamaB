using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicketLog
{
    public interface ITicketLogService
    {
        Task<TicketLogResponse> CreateTicketLog(TicketLogRequest request);
        Task<TicketLogResponse> UpdateTicketLog(int idTicketLog, TicketLogRequest ticketLogRequest);
        Task<List<TicketLogResponse>> GetAll();
        Task<TicketLogResponse> getById(int idTicketLog);

        Task<bool> DeleteTicketLog(int idTicketLog);
    }
}
