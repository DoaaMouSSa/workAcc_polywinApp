using PloyWinContext.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    //العمليات اليوميه داخل الخزنه من مشتريات اومبيعات ورصيد اول المده
    //وسحب وايداع
    public class TbltreasuryBank:BaseEntity
    {
        public string Name { get; set; }
        public string type { get; set; }
        public int Balance { get; set; }
        public int userId { get; set; }
        public string OrderType { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public int Left { get; set; }
        [ForeignKey(nameof(TblBank))]
        public int? Bank_Id { get; set; }
        public virtual TblBank TblBank { get; set; }
        [ForeignKey(nameof(TblPaymentMethods))]
        public int? Payment_Id { get; set; }
        public virtual TblPaymentMethods TblPaymentMethods { get; set; }
        [ForeignKey(nameof(TblCurrency))]
        public int? CurrencyId { get; set; }
        public virtual TblCurrency TblCurrency { get; set; }
        public string emp_name { get; set; }
        public string LogoPath { get; set; }
    }
}
