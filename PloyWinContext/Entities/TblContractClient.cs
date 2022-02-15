using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول العقود بين الورشة والعميل
    public class TblContractClient : BaseEntity
    {
        //  رقم الفاتورة
        public int? InvoicesNumber { get; set; }
        // من الشخص الورشة
        public string FromUserId { get; set; }
        // الى الشخص العميل
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

        public virtual List<TblContractCostCalc> TblContractCostCalc { get; set; }

        // المدفوع
        //[Column(TypeName = "decimal(16,2)")]
        //public decimal? TotalPayed { get; set; }
        // المتبقى
        //[Column(TypeName = "decimal(16,2)")]
        //public decimal? TotalAmount { get; set; }
    }
}
