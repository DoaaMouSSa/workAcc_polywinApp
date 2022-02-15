using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول الخصومات
    public class TblDescount : BaseEntity
    {
        //نوع الخصم للوكيل ام الورش
        public int? TypeOfDescount { get; set; }
        // نوع الخصم نسبة مئوية ام رقم صحيح
        public bool? TypeDescount { get; set; }
        // قيمة الخصم
        [Column(TypeName = "decimal(16,2)")]
        public decimal? Descount { get; set; }
        // نوع المنتج قطاعات ام اكسسوارات
        [ForeignKey(nameof(TblParentProductCategory))]
        public int? TypeOfCategory { get; set; }
        public virtual TblParentProductCategory TblParentProductCategory { get; set; }
    }
}
