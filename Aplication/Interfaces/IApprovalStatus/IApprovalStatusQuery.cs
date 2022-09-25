using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IApprovalStatus
{
    public interface IApprovalStatusQuery
    {
        List<ApprovalStatus> GetListApprovalStatus();
        ApprovalStatus getApprovalStatus(int idApprovalStatus);
        ApprovalStatus UpdateApprovalStatus(int idApprovalStatus, ApprovalStatusRequest approvalStatusRequest);
        bool DeleteApprovalStatus(int idApprovalStatus);
    }
}
