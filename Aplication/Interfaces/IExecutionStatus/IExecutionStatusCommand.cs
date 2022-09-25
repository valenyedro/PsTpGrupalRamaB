using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IExecutionStatus
{
    public interface IExecutionStatusCommand
    {
        Task InsertExecutionStatus(ExecutionStatus executionStatus);

        Task RemoveExecutionStatus(int idExecutionStatus);
    }
}
