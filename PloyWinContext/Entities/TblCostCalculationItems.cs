using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    public class TblCostCalculationItems : BaseEntity
    {
        [ForeignKey(nameof(TblCostCalculation))]
        public int CostCalculationId { get; set; }
        public virtual TblCostCalculation TblCostCalculation { get; set; }

        [ForeignKey(nameof(TblProductName))]
        public int productId { get; set; }
        public virtual TblProductName TblProductName { get; set; }

        public string meter { get; set; }
        public string cost { get; set; }
        public string totalMeterCost { get; set; }
        public string descount { get; set; }
        public string typeOfDescount { get; set; }
        public string totalByDescount { get; set; } 
    }
}
