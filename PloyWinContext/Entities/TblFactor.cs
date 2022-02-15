using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    //جدول خاص بفايل التخصيمات
    public class TblFactor : BaseEntity
    {
        public string Description { get; set; }
        public string filePath { get; set; }
        public string LogoPath { get; set; }
    }
}
