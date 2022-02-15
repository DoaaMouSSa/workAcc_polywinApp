using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول الصور الخاصة بتركيب الورشة للعميل
    public class TblGallaryUser : BaseEntity
    {
        public string ImgURL { get; set; }
        [ForeignKey(nameof(TblContractCostCalc))]
        public int? ContractItemId { get; set; }
    }
}
