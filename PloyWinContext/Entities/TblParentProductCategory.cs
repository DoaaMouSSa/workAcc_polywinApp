using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول الاقسام العام زى قطاعات واكسسوارات
    public class TblParentProductCategory : BaseEntity
    {
        public string CatgoryName { get; set; }
        public bool? haveIron { get; set; }
    }
}
