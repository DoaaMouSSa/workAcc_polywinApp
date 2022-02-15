using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول الاقسام تحت اى بند زى قطاع اكسسوارات والقسم زى نظام مفصلى
    public class TblCategory : BaseEntity
    {
        public string CategoryName { get; set; }
        [ForeignKey(nameof(TblParentProductCategory))]
        public int? TypeOfCategory { get; set; }
        public virtual TblParentProductCategory TblParentProductCategory { get; set; }
    }
}
