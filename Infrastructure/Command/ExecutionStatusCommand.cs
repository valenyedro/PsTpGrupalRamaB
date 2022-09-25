using Aplication.Interfaces.IExecutionStatus;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class ExecutionStatusCommand : IExecutionStatusCommand
    {
        private readonly AppDbContext _context;

        public ExecutionStatusCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertExecutionStatus(ExecutionStatus executionStatus)
        {
            _context.Add(executionStatus);
            await _context.SaveChangesAsync();
        }

        public Task RemoveExecutionStatus(int idExecutionStatus)
        {
            throw new NotImplementedException();
        }
    }
}
