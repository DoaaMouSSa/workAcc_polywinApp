using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile fileUpload { get; set; }
        public string FilePath { get; set; }
        public IFormFile Logo { get; set; }
        public string LogoUrl { get; set; }
        public int ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }
        public List<DtoProductIngredients> ListProductIngredients { get; set; }
        public List<DtoProductIngredientAccessory> ListDtoProductIngredientAccessory { get; set; }

    }
    public class DtoSubCategoryForDropDown
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
