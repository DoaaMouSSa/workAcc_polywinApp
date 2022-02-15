using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول خاص بالمعرض 
    public class TblGallery : BaseEntity
    {
        public string ImageGallery { get; set; }
        public string Description { get; set; }
        public int TypeGallery { get; set; }

        [ForeignKey(nameof(TblCategoryChildGallery))]
        public int CategoryChildGallaryId { get; set; }
        public virtual TblCategoryChildGallery TblCategoryChildGallery { get; set; }
    }
}
