
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoProductIngredientAccessory
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int Id { get; set; } 
        public int CountOfItems { get; set; }
    }
}
