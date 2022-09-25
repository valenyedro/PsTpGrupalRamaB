using Aplication.Interfaces.IApprovalStatus;
using Aplication.Models;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class ApprovalStatusQuery : IApprovalStatusQuery
    {
        private readonly AppDbContext _context;

        public ApprovalStatusQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<ApprovalStatus> GetListApprovalStatus()
        {
            var approvalStatus = _context.ApprovalStatus.ToList();
            return approvalStatus;
        }

        public ApprovalStatus getApprovalStatus(int idApprovalStatus)
        {
            var approvalStatus = _context.ApprovalStatus.FirstOrDefault(t => t.idApprovalStatus == idApprovalStatus);
            return approvalStatus;
        }

        public ApprovalStatus UpdateApprovalStatus(int idApprovalStatus, ApprovalStatusRequest approvalStatusRequest)
        {
            var approvalStat = _context.ApprovalStatus.FirstOrDefault(t => t.idApprovalStatus == idApprovalStatus);
            if (approvalStat == null)
            {
                return null; ;
            }

            approvalStat.description = approvalStat.description;
            _context.SaveChanges();

            return approvalStat;
        }

        public bool DeleteApprovalStatus(int idApprovalStatus)
        {
            var approvalStatus = _context.ApprovalStatus.FirstOrDefault(t => t.idApprovalStatus == idApprovalStatus);
            if (approvalStatus == null)
            {
                return false;
            }
            _context.ApprovalStatus.Remove(approvalStatus);
            _context.SaveChanges();
            return true;
        }
    }
}
