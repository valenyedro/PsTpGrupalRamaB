using Aplication.Interfaces.IExecutionStatus;
using Aplication.Models;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class ExecutionStatusQuery : IExecutionStatusQuery
    {
        private readonly AppDbContext _context;

        public ExecutionStatusQuery(AppDbContext context)
        {
            _context = context;
        }

        public bool DeleteExecutionStatus(int idExecutionStatus)
        {
            var executionStatus = _context.ExecutionStatus.FirstOrDefault(t => t.idExecutionStatus == idExecutionStatus);
            if (executionStatus == null)
            {
                return false;
            }
            _context.ExecutionStatus.Remove(executionStatus);
            _context.SaveChanges();
            return true;
        }

        public ExecutionStatus getExecutionStatus(int idExecutionStatus)
        {
            var executionStatus = _context.ExecutionStatus.FirstOrDefault(t => t.idExecutionStatus == idExecutionStatus);
            return executionStatus;
        }

        public List<ExecutionStatus> GetListExecutionStatus()
        {
            var executionStatus = _context.ExecutionStatus.ToList();
            return executionStatus;
        }

        public ExecutionStatus UpdateExecutionStatus(int idExecutionStatus, ExecutionStatusRequest executionStatusRequest)
        {
            var executionStatus = _context.ExecutionStatus.FirstOrDefault(t => t.idExecutionStatus == idExecutionStatus);
            if (executionStatus == null)
            {
                return null; ;
            }

            executionStatus.description = executionStatusRequest.description;
            _context.SaveChanges();

            return executionStatus;
        }
    }
}
