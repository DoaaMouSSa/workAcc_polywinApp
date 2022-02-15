using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول تفاصيل الفاتورة
    public class TblInvoicesDetails : BaseEntity
    {
        // رقم الفاتورة
        [ForeignKey(nameof(TblInvoices))]
        public int? InvoiceId { get; set; }
        public virtual TblInvoices Invoice { get; set; }

        // المنتج
        [ForeignKey(nameof(TblProducts))]
        public int? ProductId { get; set; }
        public virtual TblProducts Product { get; set; }
        // عدد الحديد
        public int? NumberIron { get; set; }
        // نوع المنتج قطاعات او اكسسوارات
        public int? TypeOfProduct { get; set; }
        // الكمية
        public int? Quantity { get; set; }
        // سعر المنتج
        [Column(TypeName = "decimal(16,2)")]
        public decimal? PricePerOne { get; set; }
        // سعر المنتج بالمتر
        [Column(TypeName = "decimal(16,2)")]
        public decimal? PricePerMeter { get; set; }
        // سعر الخصم
        [Column(TypeName = "decimal(16,2)")]
        public decimal? Descount { get; set; }
        public bool? haveIron { get; set; }
        // الاجمالى بعد الخصم
        [Column(TypeName = "decimal(16,2)")]
        public decimal? PriceWithDescount { get; set; }

        public bool? IsRecived { get; set; }
        public string Description { get; set; }
    }
}
