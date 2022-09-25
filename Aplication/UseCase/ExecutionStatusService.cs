using Aplication.Interfaces;
using Aplication.Interfaces.IExecutionStatus;
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
    public class ExecutionStatusService : IExecutionStatusServices
    {
        private readonly IExecutionStatusCommand _command;
        private readonly IExecutionStatusQuery _query;

        public ExecutionStatusService(IExecutionStatusCommand command, IExecutionStatusQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<ExecutionStatusResponse> CreateExecutionStatus(ExecutionStatusRequest request)
        {
            var executionStatus = new ExecutionStatus
            {
                description = request.description,
            };

            await _command.InsertExecutionStatus(executionStatus);
            return new ExecutionStatusResponse
            {
                description = request.description,
            };
        }

        public async Task<bool> DeleteExecutionStatus(int idExecutionStatus)
        {
            return await Task.FromResult(_query.DeleteExecutionStatus(idExecutionStatus));
        }

        public Task<List<ExecutionStatusResponse>> GetAll()
        {
            var executionStatus = _query.GetListExecutionStatus();
            List<ExecutionStatusResponse> result = new List<ExecutionStatusResponse>();

            foreach (ExecutionStatus executeStatus in executionStatus)
            {
                var executionStatusResponse = new ExecutionStatusResponse
                {
                    idExecutionStatus = executeStatus.idExecutionStatus,
                    description = executeStatus.description,
                };

                result.Add(executionStatusResponse);
            }
            return Task.FromResult(result);
        }

        public Task<ExecutionStatusResponse> getById(int idExecutionStatus)
        {
            var executionStatus = _query.getExecutionStatus(idExecutionStatus);
            if (executionStatus == null)
            {
                return null;
            }
            return Task.FromResult(new ExecutionStatusResponse
            {
                idExecutionStatus = executionStatus.idExecutionStatus,
                description = executionStatus.description,
            });
        }

        public Task<ExecutionStatusResponse> UpdateExecutionStatus(int idExecutionStatus, ExecutionStatusRequest executionStatusRequest)
        {
            var executionStatus = _query.UpdateExecutionStatus(idExecutionStatus, executionStatusRequest);
            if (executionStatus == null)
            {
                return null;
            }
            return Task.FromResult(new ExecutionStatusResponse
            {
                idExecutionStatus = executionStatus.idExecutionStatus,
                description = executionStatus.description,
            });
        }
    }
}
