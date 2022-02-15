using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DTOCategory
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string typeOfCategoryName { get; set; }
        public int? typeOfCategoryId { get; set; }
        public List<DtoProducts> Products { get; set; }
    }

    public class DTOCategoryNamed
    {
        public int id { get; set; }
        public string typeOfCategoryName { get; set; }
    }

    public class DTOCategoryAddEdit
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public int typeOfCategory { get; set; }
        public string typeOfCategoryName { get; set; }
    }

    public class DtoGroupCategoryWithProduct
    {
        public int Id { get; set; }
        public string ParentCategory { get; set; }
        public bool? haveIron { get; set; }
        public List<DTOCategory> ListCategory { get; set; }
    }
}
