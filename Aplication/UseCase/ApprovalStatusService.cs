using Aplication.Interfaces;
using Aplication.Interfaces.IApprovalStatus;
using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class ApprovalStatusService : IApprovalStatusService
    {
        private readonly IApprovalStatusCommand _command;
        private readonly IApprovalStatusQuery _query;

        public ApprovalStatusService(IApprovalStatusCommand command, IApprovalStatusQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<ApprovalStatusResponse> CreateApprovalStatus(ApprovalStatusRequest request)
        {
            var approvalStatus = new ApprovalStatus
            {
                description = request.description,
            };

            await _command.InsertApprovalStatus(approvalStatus);
            return new ApprovalStatusResponse
            {
                description = request.description,
            };
        }

        public async Task<bool> DeleteApprovalStatus(int idApprovalStatus)
        {
            return await Task.FromResult(_query.DeleteApprovalStatus(idApprovalStatus));
        }

        public Task<List<ApprovalStatusResponse>> GetAll()
        {
            var approvalStatusList = _query.GetListApprovalStatus();
            List<ApprovalStatusResponse> result = new List<ApprovalStatusResponse>();

            foreach (ApprovalStatus approvalStatus in approvalStatusList)
            {
                var approvalStatusResponse = new ApprovalStatusResponse
                {
                    idApprovalStatus = approvalStatus.idApprovalStatus,
                    description = approvalStatus.description,
                };

                result.Add(approvalStatusResponse);
            }
            return Task.FromResult(result);
        }

        public Task<ApprovalStatusResponse> getById(int idApprovalStatus)
        {
            var approvalStatus = _query.getApprovalStatus(idApprovalStatus);
            if (approvalStatus == null)
            {
                return null;
            }
            return Task.FromResult(new ApprovalStatusResponse
            {
                idApprovalStatus = approvalStatus.idApprovalStatus,
                description = approvalStatus.description,
            });
        }

        Task<ApprovalStatusResponse> IApprovalStatusService.UpdateApprovalStatus(int idApprovalStatus, ApprovalStatusRequest approvalStatusRequest)
        {

            var approvalStatus = _query.UpdateApprovalStatus(idApprovalStatus, approvalStatusRequest);
            if (approvalStatus == null)
            {
                return null;
            }
            return Task.FromResult(new ApprovalStatusResponse
            {
                idApprovalStatus = approvalStatus.idApprovalStatus,
                description = approvalStatus.description,
            });
        }
    }
}
