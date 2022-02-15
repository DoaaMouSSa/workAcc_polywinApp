using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IInvoiceDetailsRepository : IGenericRepository<TblInvoicesDetails>
    {
        Task<bool> AddInvoicesDetails(int invoiceId, List<DtoInvoiceDetails> dtoInvoiceDetails);
        Task<Response<List<DtoInvoiceDetails>>> GetInvoicesDetails(int invoiceId);
        Task<bool> UpdateInvoicesDetails(List<DtoUpdateInvoiceDetails> ids);
        Task UpdateInvoicesDetailsWithInvoices(int invoiceId, bool isRecived, string descrition);
        bool UpdateQuantityInvoicesDetails(int Id, int Qty);
    }
}
