using PloyWinContext.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    public class TblPurchase:BaseEntity
    {
        [ForeignKey(nameof(TblProductName))]
        public int? ProuctId { get; set; }
        public virtual TblProductName TblProductName { get; set; }
        [ForeignKey(nameof(TblSupplier))]
        public int? SupplierId { get; set; }
        public virtual TblSupplier TblSupplier { get; set; }
        [ForeignKey(nameof(TblItemType))]
        public int? ItemTypeId { get; set; }
        public virtual TblItemType TblItemType { get; set; }
        [ForeignKey(nameof(TblCurrency))]
        public int? CurrencyId { get; set; }
        public virtual TblCurrency TblCurrency { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal priceForOnePiece { get; set; }
        //عدد القطع داخل الكرتونه
        public int NumberOfPieces { get; set; }

        //سعر القطع==سعر الكرتونه مثلا
        [Column(TypeName = "decimal(18,4)")]

        public decimal PriceOfAllPieces { get; set; }
        //عدد الكرتون مثلا
        public int qty { get; set; }
        //اجمالى الدفع
        [Column(TypeName = "decimal(18,4)")]

        public decimal totalPrice_purchase { get; set; }
    }
}
