using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoInstallment
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public int? ContractId { get; set; }
        public double TotalContract { get; set; }
        public int NumberInstallment { get; set; }
        public DateTime DateInstallment { get; set; }
    }

    public class DtoListInstallment
    {
        public string ClientId { get; set; }
        public double CostPerMonth { get; set; }
        public string DateOfMonth { get; set; }

    }


    public class DtoInstallmentForView
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public double? CostPerMonth { get; set; }
        public string DateOfMonth { get; set; }
        public string type { get; set; }
    }
}
