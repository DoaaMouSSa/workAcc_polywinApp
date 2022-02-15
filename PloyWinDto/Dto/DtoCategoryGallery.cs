using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoCategoryGallery
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryTypeId { get; set; }
        public string CategoryTypeName { get; set; }
    }

    public class DtoCategoryChildGallery
    {
        public int Id { get; set; }
        public string CategoryChildName { get; set; }
        public int? CategoryGalleryId { get; set; }
        public string CategoryGalleryName { get; set; }
    }
}
