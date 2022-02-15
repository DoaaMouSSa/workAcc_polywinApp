using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول العملاء
    public class TblClient : BaseEntity
    {
        // الاسم
        public string Name { get; set; }
        // صورة العميل
        public string ClientLogo { get; set; }
        // العنوان
        public string ClientAddress { get; set; }
        // تليفون العميل
        public string ClientPhone { get; set; }
        // اسم المستخدم
        public string UserId { get; set; }
        // خط العرض
        public string Long { get; set; }
        // خط الطول
        public string Late { get; set; }
        //نوع العميل
        [ForeignKey(nameof(TblClientType))]
        public int ClientTypeId { get; set; }
        public virtual TblClientType TblClientType { get; set; }
        //البريد الالكترونى
        public string Email { get; set; }
        public string device_id { get; set; }
    }
}
