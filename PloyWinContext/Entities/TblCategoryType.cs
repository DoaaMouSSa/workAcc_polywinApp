using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    //جدول انواع الملفات صور او فيديو
    public class TblCategoryType : BaseEntity
    {
        public string TypeName { get; set; }

        public virtual List<TblCategoryGallary> TblCategoryGallaries { get; set; }
    }
}
