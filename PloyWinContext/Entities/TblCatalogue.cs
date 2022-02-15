using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    //جدول الخاص بعرض الكاتالوج فى الحساب العام
    public class TblCatalogue : BaseEntity
    {
        public string Description { get; set; }
        public string filePath { get; set; }
        public string LogoPath { get; set; }
    }
}
