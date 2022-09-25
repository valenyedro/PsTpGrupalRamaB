using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class TicketRequest
    {
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
    }
}
