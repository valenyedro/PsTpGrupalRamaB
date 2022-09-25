using Aplication.Models;
using Aplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface ITicketCategoryService
    {
        Task<TicketCategoryResponse> CreateTicketCategory(TicketCategoryRequest request);
        Task<TicketCategoryResponse> UpdateTicketCategory(int idCategory, TicketCategoryRequest ticketCategoryRequest);
        Task<List<TicketCategoryResponse>> GetAll();
        Task<TicketCategoryResponse> getById(int idCategory);

        Task<bool> DeleteTicketCategory(int idCategory);
    }
}
