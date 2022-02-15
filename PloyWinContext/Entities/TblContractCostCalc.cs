using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    public class TblContractCostCalc : BaseEntity
    {
        //نوع المنتج
        [ForeignKey(nameof(TblCostCalculation))]
        public int CostCalcId { get; set; }
        public virtual TblCostCalculation TblCostCalculation { get; set; }
        //نوع العقد
        [ForeignKey(nameof(TblContractClient))]
        public int? ContractId { get; set; }
        public virtual TblContractClient TblContractClient { get; set; }

        public bool? IsWaranty { get; set; }
    }
}
