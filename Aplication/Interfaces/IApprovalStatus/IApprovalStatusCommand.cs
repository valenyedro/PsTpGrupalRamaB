using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IApprovalStatus
{
    public interface IApprovalStatusCommand
    {
        Task InsertApprovalStatus(ApprovalStatus approvalStatus);

        Task RemoveApprovalStatus(int idApprovalStatus);
    }
}
