using IPloyWinRepository.InterFace;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinRepository.Repository
{
    public class ContractCostCalcRepository : GenericRepository<ApplicationContext, TblContractCostCalc>, IContractCostCalcRepository
    {
        public void AddContractCostCalc(int? ContractId, string ids)
        {
            var listId = ids.Split(',').ToList();

            foreach (var item in listId)
            {
                var objCost = new TblContractCostCalc()
                {
                    AddedDate = DateTime.Now,
                    ContractId = ContractId,
                    CostCalcId = Convert.ToInt32(item)
                };

                Add(objCost);
                Save();
            }
        }


        public void UpdateWarantyCostCal(int? ContractId)
        {
            var updateContract = FindBy(x => x.ContractId == ContractId).FirstOrDefault();

            if (updateContract != null)
            {
                updateContract.IsWaranty = true;

                Edit(updateContract);
                Save();
            }
        }
    }
}
