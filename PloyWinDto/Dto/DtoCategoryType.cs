using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoCategoryType
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class DtoCategoryTypeWithChild
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<DtoCategoryGalleryViewModal> listCategoryGallery { get; set; }
    }

    public class DtoCategoryGalleryViewModal
    {

        public int id { get; set; }
        public string name { get; set; }
        public List<DtoChildCategoryGallery> ListGallery { get; set; }
    }

    public class DtoGalleryViewModales
    {
        public int Id { get; set; }
        public string PathImage { get; set; }
        public string Description { get; set; }
        public int GalleryType { get; set; }
    }
}
