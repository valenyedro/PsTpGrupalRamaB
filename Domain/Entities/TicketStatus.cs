using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TicketStatus
    {
        public int idStatus { get; set; } 
        public string description { get; set; }

        public List<Ticket> tickets { get; set; }
    }
}
