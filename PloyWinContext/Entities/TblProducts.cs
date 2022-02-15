using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول المنتجات
    public class TblProducts : BaseEntity
    {
        //كود الصنف
        public string ProductCode { get; set; }
        //اللون
        [ForeignKey(nameof(TblColors))]
        public int? ColorId { get; set; }
        public virtual TblColors TblColors { get; set; }
        //المنتج
        [ForeignKey(nameof(TblProductName))]
        public int ProductId { get; set; }
        public virtual TblProductName TblProductName { get; set; }
        //نوع القسم
        [ForeignKey(nameof(TblCategory))]
        public int CategoryId { get; set; }
        public virtual TblCategory TblCategory { get; set; }
        // سعر المنتج
        [Column(TypeName = "decimal(16,2)")]
        public decimal? PricePerOne { get; set; }
        // اسم المنتج
        public string Name { get; set; } 
        // اجمالى الكمية فى الوحدة
        public int? TotalQuota { get; set; }

        //السعر بالمتر
        [Column(TypeName = "decimal(16,2)")]
        public decimal? PricePerMeter { get; set; }
        //وحدة القياس
        public string MeasruingUnit { get; set; }

        public int MaxLength { get; set; }
        public int MinLength { get; set; }

        public virtual List<TblProductIngredients> TblProductIngredients { get; set; }
        public virtual List<TblProductIngredientAccessory> TblProductIngredientAccessory { get; set; }

    }
}
