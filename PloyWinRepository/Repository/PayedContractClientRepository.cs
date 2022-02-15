using IPloyWinRepository.InterFace;
using Microsoft.EntityFrameworkCore;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using PloyWinRepository.EnumData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinRepository.Repository
{
    public class PayedContractClientRepository : GenericRepository<ApplicationContext, TblPayedContractClient>, IPayedContractClientRepository
    {
        public Response<List<DtoPayedAfterCreate>> AddPayedOfContract(DtoPayedClient dtoPayedClient)
        {
            Response<List<DtoPayedAfterCreate>> res = new Response<List<DtoPayedAfterCreate>>();
            List<DtoPayedAfterCreate> result = new List<DtoPayedAfterCreate>();
            decimal? MoneyPerMonth = Math.Round((decimal)(dtoPayedClient.TotalContract / dtoPayedClient.NumberOfPayments), 2);

            for (int i = 0; i < dtoPayedClient.NumberOfPayments; i++)
            {
                var objPayed = new TblPayedContractClient()
                {
                    AddedDate = DateTime.Now,
                    CreationDate = DateTime.Now,
                    UserId = dtoPayedClient.UserId,
                    moneyPerMonth = MoneyPerMonth,
                    IsPayed = false,
                    VisicalDate = DateTime.Now.AddMonths((i + 1)),
                    ContractClientId = dtoPayedClient.ContractId
                };

                Add(objPayed);
                Save();

                result.Add(new DtoPayedAfterCreate { Id = objPayed.Id, MoneyPerMonth = objPayed.moneyPerMonth, VisicalDate = objPayed.VisicalDate });
            }

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.payload = result;
            return res;
        }

        public Response<bool> UpdateBulkInvoice(int id)
        {
            Response<bool> res = new Response<bool>();

            var isExist = FindBy(x => x.Id == id).FirstOrDefault();
            bool IsUpdate = false;
            if (isExist != null)
            {
                isExist.IsPayed = true;
                isExist.ModifiedDate = DateTime.Now;
                isExist.DateRealPayed = DateTime.Now;

                Edit(isExist);
                Save();

                IsUpdate = true;

                res.code = StaticApiStatus.ApiSaveSuccess.Code;
                res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
                res.status = StaticApiStatus.ApiSaveSuccess.Status;
                res.payload = IsUpdate;
                return res;
            }

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.payload = IsUpdate;
            return res;
        }

        public Response<List<DtoPayedBeforeCreate>> GetAllPayedByClientId(string UserId, int ContractId)
        {
            Response<List<DtoPayedBeforeCreate>> res = new Response<List<DtoPayedBeforeCreate>>();

            var result = (from q in Context.TblPayedContractClient.AsNoTracking().Where(x => x.IsDeleted == null && x.UserId == UserId && x.ContractClientId == ContractId)
                          select new DtoPayedBeforeCreate
                          {
                              Id = q.Id,
                              CreationDate = q.CreationDate,
                              IsPayed = q.IsPayed == true ? "تم الدفع" : "لم تسلم الدفعة",
                              MoneyPerMonth = q.moneyPerMonth,
                              VisicalDate = q.VisicalDate
                          }).ToList();

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.payload = result;
            return res;

        }
    }
}
