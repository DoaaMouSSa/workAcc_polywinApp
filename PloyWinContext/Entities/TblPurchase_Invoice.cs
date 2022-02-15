using PloyWinContext.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
   public class TblPurchase_Invoice:BaseEntity
    {
        public string Code { get; set; }
        [ForeignKey(nameof(TblSupplier))]
        public int? SupplierId { get; set; }
        public virtual TblSupplier TblSupplier { get; set; }
        public string ClientName { get; set; }
        public string Type { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price_Invoice { get; set; }
        [ForeignKey(nameof(TblCurrency))]
        public int? CurrencyId { get; set; }
        public virtual TblCurrency TblCurrency { get; set; }
        public virtual List<TblPurchase_Invoices_Details> ListPurchase_Invoices_Details { get; set; }
    }
}
