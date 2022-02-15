using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPloyWinRepository.InterFace;
using PloyWinDto.Dto;
using PloyWinRepository.EnumData;

namespace PloyWinRepository.Repository
{
  public  class guaranteeRepository: IguaranteeRepository
    {
        public Response<List<string>> GetguaranteeText() {

            string str = "نضمن نحن بولى وين مصر متمثل فى ورشة*ممثلنا فى محافظة*الأبواب والشبابيك المصنعة بتاريخ*مدة عشرون عاما ضد عيوب الصناعة على القطاعات وخمسة اعوام على الاكسسورات";
            Response<List<string>> res = new Response<List<string>>();
            var result = str.Split('*').ToList();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }
    }
} 
