using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    public class TblWarrantyContracts : BaseEntity
    {
        //العقد
        [ForeignKey(nameof(TblContractClient))]
        public int? ContractId { get; set; }
        public virtual TblContractClient TblContractClient { get; set; }
        public DateTime? StartSectorsWarrantyDate { get; set; }
        public DateTime? EndSectorsWarrantyDate { get; set; }
        public DateTime? StartAccessoresWarrantyDate { get; set; }
        public DateTime? EndAccessoresWarrantyDate { get; set; }
        //المنتج
        [ForeignKey(nameof(TblCostCalculation))]
        public int? ContractCostCalcId { get; set; }
        public virtual TblContractCostCalc TblCostCalculation { get; set; }
    }
}
