using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoGallery
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
        public string[] ListImages { get; set; }
    }

    public class DtoGalleryGroup
    {
        public string CategoryName { get; set; }
        public List<DtoGalleryList> listGallery { get; set; }
    }

    public class DtoGalleryList
    {
        public int Id { get; set; }
        public string GalleryImage { get; set; }
    }

    public class DtoGalleryViewModal
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string filePath { get; set; }
        public int TypeGallery { get; set; }
        public IFormFile fileUpload { get; set; }
    }

    public class DtoGalleryForViewModal
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
