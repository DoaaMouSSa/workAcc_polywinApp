using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول تسجيل قطاعات او اكسسوارات خاص بالمعرض
    public class TblCategoryGallary : BaseEntity
    {
        public string CategoryName { get; set; }

        [ForeignKey(nameof(TblCategoryType))]
        public int CategoryTypeId { get; set; }
        public virtual TblCategoryType TblCategoryType { get; set; }
        public virtual List<TblCategoryChildGallery> TblCategoryChildGallery { get; set; }
    }
}
