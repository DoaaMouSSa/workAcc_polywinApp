using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // الاقسام الفرعية
   public class TblCategoryChildGallery : BaseEntity
    {
        public string CategoryChildName { get; set; }
        public string filePath { get; set; }
        [ForeignKey(nameof(TblCategoryGallary))]
        public int? CategoryGallaryId { get; set; }
        public virtual TblCategoryGallary CategoryGallary { get; set; }
        public virtual List<TblGallery> TblGallery { get; set; }
    }
}
