using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoChildCategoryGallery
    {
        public int Id { get; set; }
        public string CategoryChildName { get; set; }
        public string filePath { get; set; }
        public List<DtoGalleryViewModales> Gallery { get; set; }
    }
}
