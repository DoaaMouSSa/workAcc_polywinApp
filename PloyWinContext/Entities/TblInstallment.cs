using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    public class TblInstallment : BaseEntity
    {
        public string ClientId { get; set; }
        [ForeignKey(nameof(TblContractClient))]
        public int? ContractId { get; set; }
        public virtual TblContractClient TblContractClient { get; set; }
        public double? InstallMentPayment { get; set; }
        public DateTime? DateInstallMentPayment { get; set; }
        public DateTime? DatePayedInstallMentPayment { get; set; }
        public bool? IsPayed { get; set; }
    }
}
