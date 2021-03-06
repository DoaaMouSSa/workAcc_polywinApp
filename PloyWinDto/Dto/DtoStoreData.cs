using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoStoreData
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreBranch { get; set; }
        public string StoreWorker { get; set; }
        public string StorePhone { get; set; }
        public bool StoreIs_Active { get; set; }
        public string StoreAddress { get; set; }

    }
    public class DtoStoreDataForDropDown
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
    }
    public class DtoStoreDataToAdd
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreBranch { get; set; }
        public string StoreWorker { get; set; }
        public string StorePhone { get; set; }
        public bool StoreIs_Active { get; set; }
        public string StoreAddress { get; set; }
        public int user_id { get; set; }
        public int poly_show { get; set; }
        public int agent_show { get; set; }
    }
}