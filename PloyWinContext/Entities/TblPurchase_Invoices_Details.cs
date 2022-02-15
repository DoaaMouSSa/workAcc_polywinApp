using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    public class TblPurchase_Invoices_Details:BaseEntity
    {
        [ForeignKey(nameof(TblProductName))]
        public int? ProuctIdName { get; set; }
        public virtual TblProductName TblProductName { get; set; }
        [ForeignKey(nameof(TblProducts))]
        public int? ProuctId { get; set; }
        public virtual TblProducts TblProducts { get; set; }
        [ForeignKey(nameof(TblPurchase_Invoice))]
        public int? Invoice_id { get; set; }
        public virtual TblPurchase_Invoice TblPurchase_Invoice { get; set; }
        public int Qty { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TPrice_Product { get; set; }
    }
}
