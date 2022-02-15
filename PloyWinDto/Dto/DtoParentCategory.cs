using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoParentCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public IFormFile File { get; set; }
        public IFormFile Logo { get; set; }
        public string LogoUrl { get; set; }
        public List<DtoSubCategory> ListSubCategories { get; set; }


    }
    public class DtoParentCategoryForDropDown
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DtoParentSubCategory
    {
        public int Id { get; set; }
        public string ParentCategory { get; set; }
        public List<DtoListSub> ListSub { get; set; }
    }

    public class DtoListSub
    {
        public int Id { get; set; }
        public string SubCategory { get; set; }
        public string filePath { get; set; }
    }
}
