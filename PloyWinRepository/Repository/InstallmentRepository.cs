using IPloyWinRepository.InterFace;
using Microsoft.EntityFrameworkCore;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinRepository.Repository
{
    public class InstallmentRepository : GenericRepository<ApplicationContext, TblInstallment>, IInstallmentRepository
    {
        public List<DtoListInstallment> CheckInstallment(DtoInstallment dto)
        {
            List<DtoListInstallment> install = new List<DtoListInstallment>();

            if (dto != null)
            {
                var totalMonth = Math.Round((dto.TotalContract / dto.NumberInstallment), 0);

                for (int i = 1; i <= dto.NumberInstallment; i++)
                {
                    DtoListInstallment dtoList = new DtoListInstallment();

                    dtoList.CostPerMonth = totalMonth;
                    dtoList.DateOfMonth = DateTime.Now.AddMonths(i).ToString().Split("T")[0];

                    install.Add(dtoList);
                }
            }

            return install;
        }


        public bool AddNewInstallment(string clientId, int ContractId, List<DtoListInstallment> dto)
        {

            if (dto.Count() > 0)
            {
                foreach (var item in dto)
                {
                    var obj = new TblInstallment()
                    {
                        AddedDate = DateTime.Now,
                        ClientId = clientId,
                        ContractId = ContractId,
                        InstallMentPayment = item.CostPerMonth,
                        DateInstallMentPayment = Convert.ToDateTime(item.DateOfMonth),
                    };

                    Add(obj);
                    Save();
                }

                return true;
            }

            return false;
        }

        public bool UpdateInstallment(int Id)
        {
            var isExist = FindBy(x => x.Id == Id).FirstOrDefault();

            if (isExist != null)
            {
                isExist.IsPayed = true;
                isExist.DatePayedInstallMentPayment = DateTime.Now;

                Edit(isExist);
                Save();

                return true;
            }

            return false;
        }


        public List<DtoInstallmentForView> GetAllInstallmentByContractId(int ContractId)
        {
            var result = (from q in Context.TblInstallment.AsNoTracking().Where(x => x.ContractId == ContractId)
                          select new DtoInstallmentForView
                          {
                              Id = q.Id,
                              ClientName = q.TblContractClient.ToUserId,
                              CostPerMonth = q.InstallMentPayment,
                              type = q.IsPayed == true ? "تم الدفع" : "لم يتم الدفع"
                          }).ToList();


            foreach (var item in result)
            {
                var Name = Context.TblClient.Where(x => x.UserId == item.ClientName).FirstOrDefault().Name;

                item.ClientName = Name;
            }

            return result;
        }
    }
}
