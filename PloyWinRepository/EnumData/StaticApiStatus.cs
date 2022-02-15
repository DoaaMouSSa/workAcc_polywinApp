using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinRepository.EnumData
{
    public class StaticApiStatus
    {
        public static class ApiSuccess
        {
            public static string Code = "Ok";
            public static string Status = "success";
            public static string MessageEn = "Success Get Data";
            public static string MessageAr = "تم تحميل البيانات بنجاح";

        }
        public static class ApiSaveSuccess
        {
            public static string Code = "Ok";
            public static string Status = "success";
            public static string MessageEn = "Infromation is Saved";
            public static string MessageAr = "تم الحفظ بنجاح";

        }

        public static class ApiFaild
        {
            public static string Code = "Faild";
            public static string Status = "fail";
            public static string MessageEn = "Somthing Wrong";
            public static string MessageAr = "حدث خطأ اثناء تحميل البيانات";
        }
        public static class ApiDuplicate
        {
            public static string Code = "Faild";
            public static string Status = "duplicate Data";
            public static string MessageEn = "Somthing Wrong";
            public static string MessageAr = "بيان مكرر";
        }
        public static class ApiEmpty
        {
            public static string Code = "List_Empty";
            public static string Status = "empty";
            public static string MessageEn = "List is Empty";
            public static string MessageAr = "القائمة فارغة";
        }
    }
}
