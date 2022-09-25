using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TicketLog
    {
        public int idTicketLog { get; set; }
        public int idTicket { get; set; }
        public int idUser { get; set; }
        public int idUserCategory { get; set; }
        public DateTime dateHistory { get; set; }
        public int idAction { get; set; }

        public Ticket ticket { get; set; }

        public List<TicketAction> ticketActions { get; set; }
    }
}
