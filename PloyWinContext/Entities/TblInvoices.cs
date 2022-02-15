using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول فواتير المشتريات
    public class TblInvoices : BaseEntity
    {
        //  رقم الفاتورة
        public int? InvoicesNumber { get; set; }
        // من الشخص
        public string FromUserId { get; set; }
        // الى الشخص
        public string ToUserId { get; set; }
        // تاريخ الفاتورة
        public DateTime? InvoicesDate { get; set; }

        // تم التسليم ام لا
        public bool? IsRecived { get; set; }
        // ملاحظات
        public string Describtion { get; set; }
        // اجمالى الفاتورة
        [Column(TypeName = "decimal(16,2)")]
        public decimal? TotalInvoices { get; set; }
        // اجمالى الخصم
        [Column(TypeName = "decimal(16,2)")]
        public decimal? DescountInvoices { get; set; }
        // الاجمالى بعد الخصم
        [Column(TypeName = "decimal(16,2)")]
        public decimal? TotalWithInvoices { get; set; }
        // المدفوع
        [Column(TypeName = "decimal(16,2)")]
        public decimal? TotalPayed { get; set; }
        // المتبقى
        [Column(TypeName = "decimal(16,2)")]
        public decimal? TotalAmount { get; set; }
        public virtual List<TblInvoicesDetails> InvoicesDetails { get; set; }
    }
}
