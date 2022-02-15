using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    //جدول خاص  بأراء العملا
    public class TblClientOpinions :BaseEntity
    {
        public string Comment { get; set; }
        public string ImgPath { get; set; }
        public string VidPath { get; set; }
    }
}
