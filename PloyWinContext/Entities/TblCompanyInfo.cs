using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول بيانات الشركة
    public class TblCompanyInfo : BaseEntity
    {
        public string CompanyInfo { get; set; }
        public string FutureInfo { get; set; }
        public string CompanyFile { get; set; }
    }
}
