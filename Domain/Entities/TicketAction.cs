using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TicketAction
    {
        public int idAction { get; set; }
        public string actionDescription { get; set; }
        public TicketLog ticketLog { get; set; }
    }
}
