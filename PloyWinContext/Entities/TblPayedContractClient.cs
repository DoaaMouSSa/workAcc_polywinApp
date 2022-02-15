using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول الدفعات
    public class TblPayedContractClient : BaseEntity
    {
        //المستخدم
        public string UserId { get; set; }
        //المبلغ المستحق فى الشهر
        [Column(TypeName = "decimal(16,2)")]
        public decimal? moneyPerMonth { get; set; }
        // فى حالة الدفع
        public bool? IsPayed { get; set; }
        // تاريخ ان شاء الطلب
        public DateTime? CreationDate { get; set; }
        //تاريخ الدفعات
        public DateTime? VisicalDate { get; set; }
        //تاريخ الدفع الدفعات
        public DateTime? DateRealPayed { get; set; }

        [ForeignKey(nameof(TblContractClient))]
        public int? ContractClientId { get; set; }
        public virtual TblContractClient  ContractClient { get; set; }
    }
}
