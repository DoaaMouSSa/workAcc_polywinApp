

namespace PloyWinRepository.EnumData
{
    public class EnumData
    {
        public static class Colors
        {
            public static int White = 1;
            public static int Beige = 2;
            public static int Wooden = 3;
        }

        public static class TypeOfCategory
        {
            //قطاعات
            public static int Section = 1;
            //اكسسوارات
            public static int Accessories = 2;
            // اقتصادى
            public static int Economic = 3;
            // ماكينات
            public static int Machines = 4;
        }

        public static class UserType
        {
            // حساب الرئيسى
            public static int PolyWin = 1;
            // حساب الوكلاء
            public static int Agent = 2;
            // حساب الورش
            public static int Workshop = 3;
            // حساب العملاء
            public static int Client = 4;
            public static int Supplier = 5;
        }

        //انواع الوحدات المنتجات
        public static class TypeOfProduct
        {
            // الكرتونه
            public static int Carton = 1;
            // العدد
            public static int Number = 2;
            // الوزن
            public static int Weight = 3;
            // الطول
            public static int Height = 4;
            // اللفة
            public static int Lap = 5;
        }

        //انواع الفواتير
        public static class TypeOfInvoices
        {
            // فاتورة مشتريات
            public static int Carton = 1;
            // العدد
            public static int Number = 2;
            // الوزن
            public static int Weight = 3;
            // الطول
            public static int Height = 4;
            // اللفة
            public static int Lap = 5;
        }

        public static class TypeofGallery
        {
            public static int image = 1;
            public static int file = 2;
            public static int Video = 3;
        }
    }
}
