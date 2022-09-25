using Aplication.Interfaces.IApprovalStatus;
using Aplication.Models;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class ApprovalStatusCommand : IApprovalStatusCommand
    {
        private readonly AppDbContext _context;

        public ApprovalStatusCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertApprovalStatus(ApprovalStatus approvalStatus)
        {
            _context.Add(approvalStatus);
            await _context.SaveChangesAsync();

        }

        public Task RemoveApprovalStatus(int idApprovalStatus)
        {
            throw new NotImplementedException();
        }
    }
}
