using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace PloyWinDto.Dto
{
    public class DtoProductGroup
    {
        public string CategoryName { get; set; }
        public List<DtoProducts> ListProduct { get; set; }
    }
    public class DtoProducts
    {
        public int id { get; set; }
        public int? colorId { get; set; }
        public string colorName { get; set; }
        public string productCode { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public decimal? pricePerOne { get; set; }
        public string name { get; set; }
        public string imgURL { get; set; }
        public int? totalQuota { get; set; }
        public string measruingUnit { get; set; }
        public decimal? pricePerMeter { get; set; }
        public IFormFile fileUpload { get; set; }
        public int NumberIron { get; set; }
        public decimal? Descount { get; set; }
        public int? TypeOfCategory { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public string TypeDescount { get; set; }
        public List<DtoProductIngredients> ListProductIngredients { get; set; }
        public List<DtoProductIngredientAccessory> ListDtoProductIngredientAccessory { get; set; }
    }

    public class DtoProductsForDrop
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
    public class DtoProductsWithColor
    {
        public string ProductName { get; set; }
        public string productCode { get; set; }
        public string ProductColor { get; set; }
        public string ProductImg { get; set; }
    }
    public class DtoProductsWithColorGroup
    {
        public string productCode { get; set; }
        public List<DtoProductsWithColor> AllPro { get; set; }

    }
    public class DtoProductNameWithCatAndCode
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ImgURL { get; set; }
        public string productCode { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
    }
}
