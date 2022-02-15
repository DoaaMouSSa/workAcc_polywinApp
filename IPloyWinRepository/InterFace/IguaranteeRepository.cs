using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PloyWinDto.Dto;
namespace IPloyWinRepository.InterFace
{
    public interface IguaranteeRepository
    {
        public Response<List<string>> GetguaranteeText();
    }
}
