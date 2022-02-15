using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IInvoiceRepository : IGenericRepository<TblInvoices>
    {
        Task<Response<int>> GetMaxNumberIncoices();
        Task<Response<List<DtoInvoice>>> GetAllInvoicesByResived(bool? IsRecived);
        Task<Response<int>> AddNewInvoices(DtoInvoice dtoInvoice, ApplicationUser user);
        Task<Response<List<DtoInvoice>>> GetAllInvoicesFromPolyWin(int? IsRecived, ApplicationUser ToUserId);
        Task<Response<List<DtoInvoice>>> GetAllInvoicesByRecived(int? IsRecived, ApplicationUser ToUserId);
        Task<Response<List<DtoInvoice>>> GetAllInvoicesFromAgentOrWorkShop(int? IsRecived, ApplicationUser ToUserId);
        Task<Response<List<DtoTotalPayedAgent>>> GetStatisticsForAgent(int userType);
        Task<Response<bool>> UpdateInvoices(int id,string description, bool isRecived, double? totalinvoices, double? descount, double? totalwithdescount);
        Task UpdateInvoicesRescived(int id);
        Response<bool> DeleteInvoices(string Ids);
    }
}
