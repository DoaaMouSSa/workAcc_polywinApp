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
    public class ContractClientRepository : GenericRepository<ApplicationContext, TblContractClient>, IContractClientRepository
    {
        private readonly IClientRepository _clientRepository;
        private readonly IContractCostCalcRepository _contractCostCalcRepository;

        public ContractClientRepository(IClientRepository clientRepository, IContractCostCalcRepository contractCostCalcRepository)
        {
            _clientRepository = clientRepository;
            _contractCostCalcRepository = contractCostCalcRepository;
        }

        public Response<int> AddNewContract(DtoContractClient contract)
        {
            if (contract != null)
            {
                var objContract = new TblContractClient()
                {
                    FromUserId = contract.FromUserId,
                    ToUserId = contract.ToUserId,
                    AddedDate = DateTime.Now,
                    InvoicesNumber = contract.InvoicesNumber,
                    DescountInvoices = contract.DescountInvoices,
                    Describtion = contract.Describtion,
                    TotalInvoices = contract.TotalInvoices,
                    TotalWithInvoices = contract.TotalWithInvoices,
                    InvoicesDate = contract.InvoicesDate
                };

                Add(objContract);
                Save();

                _contractCostCalcRepository.AddContractCostCalc(objContract.Id, contract.NumberOfCostCalc);

                Response<int> res = new Response<int>();

                res.code = StaticApiStatus.ApiSuccess.Code;
                res.message = StaticApiStatus.ApiSuccess.MessageAr;
                res.status = StaticApiStatus.ApiSuccess.Status;
                res.payload = objContract.Id;
                return res;
            }

            Response<int> resp = new Response<int>();

            resp.code = StaticApiStatus.ApiSuccess.Code;
            resp.message = StaticApiStatus.ApiSuccess.MessageAr;
            resp.status = StaticApiStatus.ApiSuccess.Status;
            resp.payload = 0;
            return resp;
        }

        public Response<bool> UpdateContract(int id, bool isRecived)
        {
            var isExist = FindBy(x => x.Id == id).FirstOrDefault();

            if (isExist != null)
            {
                isExist.IsRecived = isRecived;
                isExist.ModifiedDate = DateTime.Now;

                Edit(isExist);
                Save();

                Response<bool> res = new Response<bool>();

                res.code = StaticApiStatus.ApiSuccess.Code;
                res.message = StaticApiStatus.ApiSuccess.MessageAr;
                res.status = StaticApiStatus.ApiSuccess.Status;
                res.payload = true;
                return res;
            }

            Response<bool> resp = new Response<bool>();

            resp.code = StaticApiStatus.ApiSuccess.Code;
            resp.message = StaticApiStatus.ApiSuccess.MessageAr;
            resp.status = StaticApiStatus.ApiSuccess.Status;
            resp.payload = false;
            return resp;
        }

        public Response<int> GetContractNumber()
        {
            Response<int> res = new Response<int>();

            var maxNumber = FindBy(x => x.IsDeleted == null).Max(x => x.InvoicesNumber) ?? 0;

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = (maxNumber + 1);
            return res;
        }

        public Response<List<DtoContractClientForView>> GetAllContractByClient(string UserId)
        {
            List<DtoContractClientForView> result = new List<DtoContractClientForView>();

            var listContract = FindBy(x => x.ToUserId == UserId).ToList();

            if (listContract.Count() > 0)
            {
                foreach (var item in listContract)
                {
                    var objClient = _clientRepository.GetClientInfoById(item.ToUserId);

                    var objWorkShop = Context.TblAgent.AsNoTracking().Where(x => x.UserId == item.FromUserId).FirstOrDefault();

                    if (objClient != null)
                    {
                        result.Add(new DtoContractClientForView
                        {
                            Id = item.Id,
                            Address = objClient.ClientAddress,
                            ClientName = objClient.Name,
                            ClientTypeName = objClient.userType,
                            InvoicesNumber = item.InvoicesNumber,
                            Phone = objClient.ClientPhone,
                            TotalContract = item.TotalInvoices,
                            WorkShopAddress = objWorkShop.AgentAddress,
                            WorkShopName = objWorkShop.NameAgent,
                            WorkShopPhone = objWorkShop.AgentPhone,
                            EmailWorkShop=objWorkShop.Email,
                            ImgWorkShop=objWorkShop.AgentLogo,
                            lat=objWorkShop.Late,
                            lang=objWorkShop.Long
                        });
                    }
                }
            }

            foreach (var item in result)
            {
                var items = Context.TblContractCostCalc.AsNoTracking().Where(x => x.ContractId == item.Id).Select(x =>
                              new ListProduct
                              {
                                  ProductName = x.TblCostCalculation.TblSubCategory.Name,
                                  ProductId = x.TblCostCalculation.Id
                              }).ToList();
                item.listItem = new List<ListProduct>();
                item.listItem.AddRange(items);
            }

            Response<List<DtoContractClientForView>> res = new Response<List<DtoContractClientForView>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public Response<List<DtoContractClientForView>> GetAllContractByWorkShop(string UserId)
        {
            
            List<DtoContractClientForView> result = new List<DtoContractClientForView>();
            var listContract = FindBy(x => x.FromUserId == UserId).ToList();

            if (listContract.Count() > 0)
            {
                foreach (var item in listContract)
                {
                    var objClient = _clientRepository.GetClientInfoById(item.ToUserId);

                    if (objClient != null)
                    {
                        result.Add(new DtoContractClientForView
                        {
                            Id = item.Id,
                            Address = objClient.ClientAddress,
                            ClientName = objClient.Name,
                            ClientTypeName = objClient.userType,
                            InvoicesNumber = item.InvoicesNumber,
                            Phone = objClient.ClientPhone,
                            TotalContract = item.TotalInvoices
                        });
                    }
                }
            }

            foreach (var item in result)
            {
                var items = Context.TblContractCostCalc.AsNoTracking().Where(x => x.ContractId == item.Id && x.IsWaranty == null).Select(x =>
                              new ListProduct
                              {
                                  Id=x.Id,
                                  ProductName = x.TblCostCalculation.TblSubCategory.Name,
                                  ProductId = x.TblCostCalculation.subCategoryId
                              }).ToList();
                item.listItem = new List<ListProduct>();

                item.listItem.AddRange(items);
            }

            Response<List<DtoContractClientForView>> res = new Response<List<DtoContractClientForView>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public ContractInfo GetContractInfoByContractId(int? contractId)
        {
            var result = (Context.TblContractClient.AsNoTracking().Where(x => x.Id == contractId).Select(x =>
                            new
                            {
                                From = x.FromUserId,
                                To = x.ToUserId,
                                Total = x.TotalInvoices,
                                InvoiceDate = x.AddedDate,
                                ListItem = x.TblContractCostCalc.ToList()
                            }).FirstOrDefault());

            var rr = new ContractInfo();

            var client = Context.TblClient.AsNoTracking().Where(x => x.UserId == result.To).FirstOrDefault();
            var workShop = Context.TblAgent.AsNoTracking().Where(x => x.UserId == result.From).FirstOrDefault();

            rr.ClientAddress = client.ClientAddress;
            rr.ClientName = client.Name;
            rr.ClientPhone = client.ClientPhone;
            rr.InvoiceDate = result.InvoiceDate.ToString().Split(" ")[0];
            rr.Total = result.Total.ToString();
            rr.WorkShopAddress = workShop.AgentAddress;
            rr.WorkShopName = workShop.Name;
            rr.WorkShopUserName = workShop.NameAgent;
            rr.WorkShopLogo = workShop.AgentLogo;
            rr.ItemList = new List<ItemList>();
            foreach (var item in result.ListItem)
            {
                var _item = new ItemList();
                 
                var dd = Context.TblCostCalculation.AsNoTracking().Where(x => x.Id == item.CostCalcId).FirstOrDefault();
                _item.ProductName = Context.TblSubCategories.AsNoTracking().Where(x => x.Id == dd.subCategoryId).FirstOrDefault().Name;
                _item.Color = Context.TblColors.AsNoTracking().Where(x => x.Id == dd.ColorId).FirstOrDefault().ColorName;
                _item.heigth = dd.height;
                _item.Width = dd.width;

                rr.ItemList.Add(_item);
            }



            return rr;
        }

    }
}
