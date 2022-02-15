using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
   public interface IMessageRepository : IGenericRepository<TblMessage>
    {
        Response<bool> AddNewMessage(DtoMessage dto);
       Response<List<DtoMessage>> GetAllMessages();

    }
}
