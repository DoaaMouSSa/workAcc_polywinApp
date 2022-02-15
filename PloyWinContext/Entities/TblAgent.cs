using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    // جدول الوكلاء والورش
    public class TblAgent : BaseEntity
    {
        //الاسم
        public string Name { get; set; }
        // اسم الشركة
        public string NameAgent { get; set; }
        // الشعار
        public string AgentLogo { get; set; }
        // المحافظة
        public string AgentGovernorate { get; set; }

        public string AgentAddress { get; set; }
        // التليفون
        public string AgentPhone { get; set; }
        // اسم المستخدم
        public string UserId { get; set; }
        // خطوط العرض
        public string Long { get; set; }
        // خطوط الطول
        public string Late { get; set; }
        //البريد الالكترونى
        public string Email { get; set; }
        //for notification
        public string device_id { get; set; }
    }
}
