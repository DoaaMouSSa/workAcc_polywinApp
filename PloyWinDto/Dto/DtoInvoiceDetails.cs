using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoInvoiceDetails
    {
        public int id { get; set; }
        public int? productId { get; set; }
        public string Color { get; set; }
        public string productName { get; set; }
        public string productPath { get; set; }
        public int? numberIron { get; set; }
        public int? typeOfProduct { get; set; }
        public string typeOfProductText { get; set; }
        public int? quantity { get; set; }
        public decimal? descount { get; set; }
        public decimal? pricePerOne { get; set; }
        public decimal? priceWithDescount { get; set; }
        public decimal? pricePerMeter { get; set; } 
        public bool? isRecived { get; set; }
        public string ImgURL { get; set; }
        public decimal totalOrder { get; set; }
        public string Description { get; set; }
    }

    public class DtoUpdateInvoiceDetails
    {
        public int? Id { get; set; }
        public int? qty { get; set; }
        public string Description { get; set; }
        public bool IsRescived { get; set; }
    }
}
