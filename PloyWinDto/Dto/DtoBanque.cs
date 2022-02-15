using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoBanque
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int currency_id { get; set; }
        public string type { get; set; }
        public int Balance { get; set; }
        public string Date { get; set; }
        public int userId { get; set; }
        public string OrderType { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public int Left { get; set; }
        public int bank_id { get; set; }
        public int payment_id { get; set; }
        public string bank_name { get; set; }
        public string payment_name { get; set; }
        public string LogoPath { get; set; }
        public IFormFile logo { get; set; }

    }
    public class DtoBanqueForDropDown
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DtoBankForDepositForAdd
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public int Balance { get; set; }
        public string Date { get; set; }
        public int userId { get; set; }
        public string OrderType { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public int Left { get; set; }
        public int currency_id { get; set; }
        public int bank_id { get; set; }
        public int payment_id { get; set; }
        public string emp_name { get; set; }
        public string filePath { get; set; }
        public IFormFile file { get; set; }
        public string LogoPath { get; set; }
        public IFormFile logo { get; set; }
    }
    public class DtoBankForDepositForShow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string type { get; set; }
        public int Balance { get; set; }
        public string Date { get; set; }
        public int userId { get; set; }
        public string OrderType { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public int Left { get; set; }
        public int bank_id { get; set; }
        public int payment_id { get; set; }
        public int currency_id { get; set; }
        public string bank_name { get; set; }
        public string payment_name { get; set; }
        public string currency_name { get; set; }
        public string emp_name { get; set; }
        public string filePath { get; set; }
        public IFormFile file { get; set; }
        public string LogoPath { get; set; }
        public IFormFile logo { get; set; }
    }
}
