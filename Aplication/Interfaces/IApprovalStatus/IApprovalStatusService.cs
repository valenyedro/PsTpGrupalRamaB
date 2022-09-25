using Aplication.Models;
using Aplication.Response;
using Aplication.UseCase;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IApprovalStatusService
    {
        Task<ApprovalStatusResponse> CreateApprovalStatus(ApprovalStatusRequest request);
        Task<ApprovalStatusResponse> UpdateApprovalStatus(int idApprovalStatus, ApprovalStatusRequest approvalStatusRequest);
        Task<List<ApprovalStatusResponse>> GetAll();
        Task<ApprovalStatusResponse> getById(int idApprovalStatus);

        Task<bool> DeleteApprovalStatus(int idApprovalStatus);
    }
}
