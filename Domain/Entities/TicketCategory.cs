using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TicketCategory
    {

        public int idCategory { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool reqApproval { get; set; }
        public DateTime dateCreate { get; set; }



        public List<Ticket> tickets { get; set; }
    }
}
