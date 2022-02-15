using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoProductIngredients
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Equation { get; set; }
    }


    public class DtoProductCost
    {
        public int? subCategoryId { get; set; }
        public int? colorId { get; set; }
        public string Width { get; set; }
        public string height { get; set; }
        public int? mortal { get; set; }
        public int? net { get; set; }
        public double? expenses { get; set; }
    }

    public class ProductCost
    {
        public int CostCalcId { get; set; }
        public double? totalExpenses { get; set; }
        public double? totalMortal { get; set; }
        public double? totalCost { get; set; }
        public double? net { get; set; }
        public List<ItemCost> items { get; set; }
    }

    public class ItemCost
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public string Meter { get; set; }
        public string Cost { get; set; }
        public string TotalMeterCost { get; set; }
        public string Descount { get; set; }
        public string TypeOfDescount { get; set; }
        public string TotalByDescount { get; set; }
        public bool Type { get; set; }
    }

    public class CostCalc
    {
        public int Id { get; set; }
        public int? subCategoryId { get; set; }
        public string subCategoryName { get; set; }
        public string PathFile { get; set; }
        public int? colorId { get; set; }
        public string colorName { get; set; }
        public string Width { get; set; }
        public string height { get; set; }
        public double? mortal { get; set; }
        public double? expenses { get; set; }
        public double? totalCalc { get; set; }
        public double? net { get; set; }
        public int? ClientId { get; set; }
        public List<CostCalcItems> CostCalcItems { get; set; }

    }

    public class CostCalcItems
    {
        public int CostCalculationId { get; set; }
        public int productId { get; set; }
        public string meter { get; set; }
        public string cost { get; set; }
        public string totalMeterCost { get; set; }
        public string descount { get; set; }
        public string typeOfDescount { get; set; }
        public string totalByDescount { get; set; }
    }
}
