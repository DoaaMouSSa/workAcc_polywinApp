using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    class TblItem:BaseEntity
    {
        public string ItemName { get; set; }
        public int ItemType_Id { get; set; }
    }
}
