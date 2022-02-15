using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    //جدول المنتجات
    public class TblProductName : BaseEntity
    {
        //اسم المنتج
        public string Name { get; set; }
        // صورة المنتج
        public string ImgURL { get; set; }
    }
}
