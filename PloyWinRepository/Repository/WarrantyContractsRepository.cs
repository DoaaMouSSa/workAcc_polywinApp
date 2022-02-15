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
    public class WarrantyContractsRepository : GenericRepository<ApplicationContext, TblWarrantyContracts>, IWarrantyContractsRepository
    {
        private readonly IContractCostCalcRepository _contractCostCalcRepository;

        public WarrantyContractsRepository(IContractCostCalcRepository contractCostCalcRepository)
        {
            _contractCostCalcRepository = contractCostCalcRepository;
        }

        public bool AddNewWarranty(DtoWarranty dto)
        {
            if (dto != null)
            {  
                var obj = new TblWarrantyContracts()
                {
                    AddedDate = DateTime.Now,
                    ContractId = dto.ContractId,
                    ContractCostCalcId = dto.ContractItemId,
                    StartSectorsWarrantyDate = DateTime.Now,
                    EndSectorsWarrantyDate = DateTime.Now.AddYears(20),
                    StartAccessoresWarrantyDate = DateTime.Now,
                    EndAccessoresWarrantyDate = DateTime.Now.AddYears(5),
                };


                Add(obj);
                Save();

                _contractCostCalcRepository.UpdateWarantyCostCal(dto.ContractId);

                return true;
            }

            return false;
        }

        public List<DtoWarrantyForView> GetAllWarrantyByClientId(string userId)
        {
            var result = (from q in Context.TblWarrantyContracts.AsNoTracking().Where(z => z.TblContractClient.ToUserId == userId)
                          select new DtoWarrantyForView
                          {
                              ContractItemId = q.ContractCostCalcId,
                              ProductName = q.TblCostCalculation.TblCostCalculation.TblSubCategory.Name,
                              StartSectorsWarrantyDate = q.StartSectorsWarrantyDate.ToString() ,
                              EndSectorsWarrantyDate = q.EndSectorsWarrantyDate.ToString(),
                              StartAccessoresWarrantyDate = q.StartAccessoresWarrantyDate.ToString(),
                              EndAccessoresWarrantyDate = q.EndAccessoresWarrantyDate.ToString(),
                          }).ToList();

            foreach (var item in result)
            {
                item.StartSectorsWarrantyDate = item.StartSectorsWarrantyDate.Split(" ")[0];
                item.EndSectorsWarrantyDate = item.EndSectorsWarrantyDate.Split(" ")[0];
                item.StartAccessoresWarrantyDate = item.StartAccessoresWarrantyDate.Split(" ")[0];
                item.EndAccessoresWarrantyDate = item.EndAccessoresWarrantyDate.Split(" ")[0];
                item.ListImage = Context.TblGallaryUser.Where(x => x.ContractItemId == item.ContractItemId).Select(x => x.ImgURL).ToList();
            }

            return result;
        }

    }
}
