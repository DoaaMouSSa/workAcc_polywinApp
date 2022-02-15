using IPloyWinRepository.InterFace;
using Microsoft.EntityFrameworkCore;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using PloyWinRepository.EnumData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinRepository.Repository
{
    public class BanqueRepository : GenericRepository<ApplicationContext, TbltreasuryBank>, IBanqueRepository
    {
        public async Task<Response<DtoBanque>> AddEditBanque(DtoBanque dtoBanque)
        {
            if (dtoBanque != null)
            {
                if (dtoBanque.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dtoBanque.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        if (dtoBanque.Name != null)
                        {
                            isExist.Name = dtoBanque.Name;
                        }
                        if (dtoBanque.type != null)
                        {
                            isExist.type = dtoBanque.type;
                        }


                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();

                        dtoBanque.Id = isExist.Id;
                        dtoBanque.Name = isExist.Name;
                        dtoBanque.type = isExist.type;
                    }
                }
                else
                {
                    var objBanque = new TbltreasuryBank()
                    {
                        AddedDate = DateTime.Now,
                        Name = dtoBanque.Name,
                        type = dtoBanque.type,
                        CurrencyId = dtoBanque.currency_id,
                        
                    };

                    Add(objBanque);
                    Save();

                    dtoBanque.Id = objBanque.Id;
                }
            }

            Response<DtoBanque> res = new Response<DtoBanque>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dtoBanque;
            return res;
        }
        //decrease
        public async Task<Response<bool>> EditBalance(int id, int newBalance)
        {
            Response<bool> res = new Response<bool>();
            //هاخد بيانات من الخزنه الى مبعوت الid بتاعها
            var bankFound = Context.TbltreasuryBank.FirstOrDefault(b => b.Id == id && b.IsDeleted == null);
            int MaxID = (from b in Context.TbltreasuryBank
                         where b.IsDeleted == null
                         select b.Id).Max();
            int LastBalance = Context.TbltreasuryBank.FirstOrDefault(b => b.Id == MaxID).Balance;
            var objBanquePurchase = new TbltreasuryBank()
            {
                AddedDate = DateTime.Now,
                Name = bankFound.Name,
                type = bankFound.type,
                CurrencyId = bankFound.CurrencyId,
                Balance = LastBalance - newBalance,
                OrderType = "مشتريات",
                In = 0,
                Out = newBalance,
                Left = 0
            };
            Add(objBanquePurchase);
            Save();
            DtoBanque dtoBanque = new DtoBanque();
            dtoBanque.Id = objBanquePurchase.Id;
            dtoBanque.In = objBanquePurchase.In;
            dtoBanque.Out = objBanquePurchase.Out;
            dtoBanque.Left = objBanquePurchase.Left;
            dtoBanque.OrderType = objBanquePurchase.OrderType;
            dtoBanque.Name = objBanquePurchase.Name;
            return res;
        }

        public async Task<Response<bool>> EditBalanceEda3(int id, int newBalance,DtoBankForDepositForAdd dto)
        {
            Response<bool> res = new Response<bool>();
            //هاخد بيانات من الخزنه الى مبعوت الid بتاعها
            var bankFound = Context.TbltreasuryBank.FirstOrDefault(b => b.Id == id && b.IsDeleted == null);
            int MaxID = (from b in Context.TbltreasuryBank
                         where b.IsDeleted == null
                         select b.Id).Max();
            int LastBalance = Context.TbltreasuryBank.FirstOrDefault(b => b.Id == MaxID).Balance;
            var objBanque = new TbltreasuryBank()
            {
                AddedDate = DateTime.Now,
                Name = bankFound.Name,
                type = bankFound.type,
                CurrencyId = dto.currency_id,
                Balance = LastBalance + newBalance,
                OrderType = "ايداع",
                In = newBalance,
                Out = 0,
                Left = 0,
             emp_name=dto.emp_name,
                LogoPath = dto.LogoPath,
             Bank_Id =dto.bank_id,
             Payment_Id=dto.payment_id
            };
            Add(objBanque);
            Save();
            DtoBankForDepositForAdd dtoBanque = new DtoBankForDepositForAdd();
            dtoBanque.Id = objBanque.Id;
            dtoBanque.In = objBanque.In;
            dtoBanque.Out = objBanque.Out;
            dtoBanque.Left = objBanque.Left;
            dtoBanque.OrderType = objBanque.OrderType;
            dtoBanque.Name = objBanque.Name;
            dtoBanque.LogoPath = objBanque.LogoPath;
            dtoBanque.emp_name = objBanque.emp_name;
            dtoBanque.bank_id = (int)objBanque.Bank_Id;
            dtoBanque.currency_id = (int)objBanque.CurrencyId;
            return res;
        }
        public async Task<Response<bool>> EditBalanceSa7b(int id, int newBalance, DtoBankForDepositForAdd dto)
        {
            Response<bool> res = new Response<bool>();
            //هاخد بيانات من الخزنه الى مبعوت الid بتاعها
            var bankFound = Context.TbltreasuryBank.FirstOrDefault(b => b.Id == id && b.IsDeleted == null);
            int MaxID = (from b in Context.TbltreasuryBank
                         where b.IsDeleted == null
                         select b.Id).Max();
            int LastBalance = Context.TbltreasuryBank.FirstOrDefault(b => b.Id == MaxID).Balance;
            var objBanque = new TbltreasuryBank()
            {
                AddedDate = DateTime.Now,
                Name = bankFound.Name,
                type = bankFound.type,
                CurrencyId = dto.currency_id,
                Balance = LastBalance - newBalance,
                OrderType = "سحب",
                In = 0,
                Out = newBalance,
                Left = 0,
                emp_name = dto.emp_name,
                LogoPath=dto.LogoPath,
                Bank_Id = dto.bank_id,
                Payment_Id = dto.payment_id
            };
            Add(objBanque);
            Save();
            DtoBankForDepositForAdd dtoBanque = new DtoBankForDepositForAdd();
            dtoBanque.Id = objBanque.Id;
            dtoBanque.In = objBanque.In;
            dtoBanque.Out = objBanque.Out;
            dtoBanque.Left = objBanque.Left;
            dtoBanque.OrderType = objBanque.OrderType;
            dtoBanque.Name = objBanque.Name;
            dtoBanque.LogoPath = objBanque.LogoPath;
            dtoBanque.emp_name = objBanque.emp_name;

            return res;
        }

        public async Task<Response<bool>> DeleteBanque(string Ids)
        {
            var listId = Ids.Split(',').ToList();

            bool dd = false;

            foreach (var Id in listId)
            {
                var result = FindBy(x => x.Id == Convert.ToInt32(Id)).FirstOrDefault();


                if (result != null)
                {
                    result.IsDeleted = true;
                    result.DeletedDate = DateTime.Now;

                    Edit(result);
                    Save();

                    dd = true;
                }
            }

            Response<bool> res = new Response<bool>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dd;
            return res;
        }


        public async Task<Response<List<DtoBankForDepositForShow>>> getBanque()
        {
            var result = (from q in Context.TbltreasuryBank.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoBankForDepositForShow
                          {
                              Id = q.Id,
                              Name = q.Name,
                              type = q.type,
                              currency_id = q.TblCurrency.Id,
                              currency_name=q.TblCurrency.Name,
                              bank_id=q.TblBank.Id,
                              bank_name=q.TblBank.nameBank,
                              payment_id=q.TblPaymentMethods.Id,
                              payment_name=q.TblPaymentMethods.namePaymentMethod,
                              emp_name=q.emp_name,
                              LogoPath = q.LogoPath,
                              Balance = q.Balance,
                              Date = q.AddedDate.GetValueOrDefault().ToString("dd-MMMM-yyyy", new CultureInfo("ar-AE")),
                              In = q.In,
                              Out = q.Out,
                              Left = q.Left,
                              OrderType = q.OrderType
                          }).ToList();
            Response<List<DtoBankForDepositForShow>> res = new Response<List<DtoBankForDepositForShow>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }
        public async Task<Response<List<DtoBanqueForDropDown>>> getBanqueForDropDown()
        {
            var result = (from q in Context.TbltreasuryBank.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoBanqueForDropDown
                          {
                              Id = q.Id,
                              Name = q.Name,
                          }).ToList();
            Response<List<DtoBanqueForDropDown>> res = new Response<List<DtoBanqueForDropDown>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }
        public async Task<Response<DtoBankForDepositForAdd>> AddDeposit(DtoBankForDepositForAdd dtoBanque)
        {
            await EditBalanceEda3(2, dtoBanque.Balance, dtoBanque);
            Response<DtoBankForDepositForAdd> res = new Response<DtoBankForDepositForAdd>();
    res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dtoBanque;
            return res;
        }
        public async Task<Response<DtoBankForDepositForAdd>> DecreaseDeposit(DtoBankForDepositForAdd dtoBanque)
        {
            await EditBalanceSa7b(2, dtoBanque.Balance, dtoBanque);
            Response<DtoBankForDepositForAdd> res = new Response<DtoBankForDepositForAdd>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dtoBanque;
            return res;
        }

    }
}
