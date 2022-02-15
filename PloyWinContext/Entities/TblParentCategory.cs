using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول خاص بتسجيل القسم العام زى باب او شباك

    public class TblParentCategory :BaseEntity
    { 
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string LogoUrl { get; set; }
        public virtual List<TblSubCategory> TblSubCategories { get; set; }
    }
}
