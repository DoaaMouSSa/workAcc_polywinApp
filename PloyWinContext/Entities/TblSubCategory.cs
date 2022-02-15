using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول خاص تفاصيل المنتج زى باب جرار
    public class TblSubCategory:BaseEntity
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string LogoUrl { get; set; }
        [ForeignKey(nameof(TblParentCategory))]
        public int ParentCategoryId { get; set; }
        public virtual TblParentCategory TblParentCategory { get; set; }
        public virtual  List<TblProductIngredients> TblProductIngredients { get; set; }
        public virtual List<TblProductIngredientAccessory> TblProductIngredientAccessory { get; set; }

    }
}
