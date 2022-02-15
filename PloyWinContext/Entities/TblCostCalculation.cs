using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    public class TblCostCalculation : BaseEntity
    {
        [ForeignKey(nameof(TblSubCategory))]
        public int? subCategoryId { get; set; }
        public virtual TblSubCategory TblSubCategory { get; set; }


        [ForeignKey(nameof(TblClient))]
        public int? ClientId { get; set; }
        public virtual TblClient TblClient { get; set; }


        [ForeignKey(nameof(TblColors))]
        public int? ColorId { get; set; }
        public virtual TblColors TblColors { get; set; }

        public string width { get; set; }
        public string height { get; set; }
        public double? mortal { get; set; }
        public double? expenses { get; set; }
        public double? net { get; set; }
        public virtual List<TblCostCalculationItems> TblCostCalculationItems { get; set; }
    }
}
