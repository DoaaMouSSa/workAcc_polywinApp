using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoStoresGroupBy
    {
        public string categoryName { get; set; }
        public List<DtoStores> ListProduct { get; set; }
    }
    public class DtoStores
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public int? productId { get; set; }
        public int? ProductIdName { get; set; }
        public string productName { get; set; }
        public string productImg { get; set; }
        public decimal  totalPriceProduct { get; set; }
        public int? quantity { get; set; }
        public string productCode { get; set; }
        public string measruingUnit { get; set; }
        public decimal? pricePerMeter { get; set; }
        public decimal? pricePerOne { get; set; }
    }
    public class DtoToAddToStore
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int productname_id { get; set; }
        public int category_id { get; set; }
        public int quantity { get; set; }
        public decimal pricePerMeter { get; set; }
    }
    public class DtoStoreFromPurchase
    {
        public int id { get; set; }
        public int productname_id { get; set; }
        public int quantity { get; set; }
    }
 
}
