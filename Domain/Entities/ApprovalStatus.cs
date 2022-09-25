using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApprovalStatus
    {
        public int idApprovalStatus { get; set; }
        public string description { get; set; }

        public List<Ticket> tickets { get; set; }
    }
}
