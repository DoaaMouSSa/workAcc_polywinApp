using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول المخزن
    public class TblStores : BaseEntity
    {
        //المخزن خاص باى مستخدم
        public string UserId { get; set; }
        // المنتج
        [ForeignKey(nameof(TblProducts))]
        public int? ProductId { get; set; }
        public virtual TblProducts TblProducts { get; set; }
        [ForeignKey(nameof(TblProductName))]
        public int? ProductIdName { get; set; }
        public virtual TblProductName TblProductName { get; set; }
        [ForeignKey(nameof(TblStoreData))]
        public string StoreData_Id { get; set; }
        //وحدة القياس
        public string MeasruingUnit { get; set; }
        //السعر بالمتر
        [Column(TypeName = "decimal(16,2)")]
        public decimal? PricePerMeter { get; set; }
        // سعر المنتج
        [Column(TypeName = "decimal(16,2)")]
        public decimal? PricePerOne { get; set; }
        public int? Quantity { get; set; }  
    }
}
