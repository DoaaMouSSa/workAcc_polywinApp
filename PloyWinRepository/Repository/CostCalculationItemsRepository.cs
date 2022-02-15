using IPloyWinRepository.InterFace;
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
    public class CostCalculationItemsRepository : GenericRepository<ApplicationContext, TblCostCalculationItems>, ICostCalculationItemsRepository
    {
        public void AddCostCalcItems(int CostCalcId, List<CostCalcItems> items)
        {
            foreach (var item in items)
            {
                var productId = Context.TblProducts.Where(x => x.ProductId == item.productId).FirstOrDefault().Id;
                
                var objitem = new TblCostCalculationItems()
                {
                    AddedDate = DateTime.Now,
                    cost = item.cost,
                    CostCalculationId = CostCalcId,
                    descount = item.descount,
                    meter = item.meter,
                    productId = item.productId,
                    totalByDescount = item.totalByDescount,
                    totalMeterCost = item.totalMeterCost,
                    typeOfDescount = item.typeOfDescount 
                };

                Add(objitem);
                Save();
            }
        }
    }
}
