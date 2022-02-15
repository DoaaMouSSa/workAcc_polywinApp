using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول خاص باداتا شيت الخاص بالحساب العام
    public class TblDataSheets : BaseEntity
    {
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
