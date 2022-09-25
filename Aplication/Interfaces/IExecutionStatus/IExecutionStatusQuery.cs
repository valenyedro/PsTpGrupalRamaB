using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IExecutionStatus
{
    public interface IExecutionStatusQuery
    {
        List<ExecutionStatus> GetListExecutionStatus();
        ExecutionStatus getExecutionStatus(int idExecutionStatus);
        ExecutionStatus UpdateExecutionStatus(int idExecutionStatus, ExecutionStatusRequest executionStatusRequest);
        bool DeleteExecutionStatus(int idExecutionStatus);
    }
}
