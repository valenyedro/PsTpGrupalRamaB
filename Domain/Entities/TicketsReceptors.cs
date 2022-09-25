using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TicketsReceptors
    {
        public int idTicketReceptors {get;set;}
    
        public int idUser {get;set;}

        public int idTicket { get; set; }
        public Ticket ticket { get; set; }
    }
}
