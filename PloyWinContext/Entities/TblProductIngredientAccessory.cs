using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    //جدول تسجيل مكونات المنتج من ناحية الاكسسوارات
    public class TblProductIngredientAccessory:BaseEntity
    {
        //product
        [ForeignKey(nameof(TblProductName))]
        public int ProductId { get; set; }
        public virtual TblProductName TblProductName { get; set; }

        //subcategory

        [ForeignKey(nameof(TblSubCategory))]
        public int SubCategoryId { get; set; }
        public virtual TblSubCategory TblSubCategory { get; set; }

        public int CountOfItems { get; set; }
    }
}
