using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        public int idTicket { get; set; }
        public int idUser { get; set; }
        public int idStatus { get; set; }
        public int idExecutionStatus { get; set; }
        public int idPriority { get; set; }
        public int idCategory { get; set; }
        public int idUserExecutor { get; set; }
        public int idApprovalStatus { get; set; }
        public int idTicketBody { get; set; }
        public int minApproveReq { get; set; }
        public int countOpen { get; set; }
        public int countDisapproved { get; set; }
        public int countApproved { get; set; }



        public TicketStatus ticketStatus { get; set; }
        public ExecutionStatus executionStatus { get; set; }
        public TicketPriority ticketPriority { get; set; }
        public TicketCategory ticketCategory { get; set; }
        public TicketBody ticketBody { get; set; }
        public ApprovalStatus approvalStatus { get; set; }


        public List<TicketComment> ticketComments { get; set; }
        public List<TicketsReceptors> ticketReceptors { get; set; }
        public List<TicketLog> ticketLogs { get; set; }
    }
}
