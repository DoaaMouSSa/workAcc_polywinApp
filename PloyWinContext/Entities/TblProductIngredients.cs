using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PloyWinContext.Entities
{
    // جدول تسجيل المعادلات الخاصة بكل قطاع
   public class TblProductIngredients:BaseEntity
   {
        //product
        [ForeignKey(nameof(TblProductName))]
        public int ProductId { get; set; }
        public virtual TblProductName TblProductName { get; set; }

        //subcategory

        [ForeignKey(nameof(TblSubCategory))]
        public int SubCategoryId { get; set; }
        public virtual TblSubCategory TblSubCategory { get; set; }
        
        public string Equation { get; set; }
    }
}
