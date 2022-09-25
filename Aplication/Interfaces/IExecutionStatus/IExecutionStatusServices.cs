using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IExecutionStatus
{
    public interface IExecutionStatusServices
    {
        Task<ExecutionStatusResponse> CreateExecutionStatus(ExecutionStatusRequest request);
        Task<ExecutionStatusResponse> UpdateExecutionStatus(int idExecutionStatus, ExecutionStatusRequest executionStatusRequest);
        Task<List<ExecutionStatusResponse>> GetAll();
        Task<ExecutionStatusResponse> getById(int idExecutionStatus);

        Task<bool> DeleteExecutionStatus(int idExecutionStatus);
    }
}
