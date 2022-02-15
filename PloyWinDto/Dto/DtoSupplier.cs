using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoSupplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // اسم الشركة
        public string SupplierName { get; set; }
        //كود المورد
        public string SupplierCode { get; set; }
        // الشعار 
        public string SupplierAddress { get; set; }
        // تليفون الشركه
        public string SupplierTelephone { get; set; }
        // التليفون
        public string SupplierPhone { get; set; }
        //البريد الالكترونى
        public string SupplierEmail { get; set; }
        public int credit_limit { get; set; }
        public string credit_period { get; set; }
    }
    public class DtoSupplierForDropDown
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DtoSupplierToAdd
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SupplierName { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierTelephone { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierEmail { get; set; }
        public int credit_limit { get; set; }
        public string credit_period { get; set; }
        public int user_id { get; set; }
        public int poly_show { get; set; }
        public int agent_show { get; set; }
    }
  
}
