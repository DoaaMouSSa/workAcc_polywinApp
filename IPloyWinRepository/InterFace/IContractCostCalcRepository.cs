using PloyWinContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IContractCostCalcRepository : IGenericRepository<TblContractCostCalc>
    {
        void AddContractCostCalc(int? ContractId, string ids);
        void UpdateWarantyCostCal(int? ContractId);
    }
}
