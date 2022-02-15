using IPloyWinRepository.InterFace;
using Microsoft.EntityFrameworkCore;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using PloyWinRepository.EnumData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PloyWinRepository.Repository
{
   public class MessageRepository: GenericRepository<ApplicationContext, TblMessage>, IMessageRepository
    {
        public Response<bool> AddNewMessage(DtoMessage dtomessage)
        {
            Response<bool> res = new Response<bool>();
            if (dtomessage != null)
            {
                var objMessage = new TblMessage()
                {
                    Name = dtomessage.Name,
                    AddedDate = DateTime.Now,
                    Email = dtomessage.Email,
                    Phone = dtomessage.Phone,
                    Message = dtomessage.Message,

                };

                Add(objMessage);
                Save();
          
            }
            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.IsSuccess = true;
            return res;
        }

        public Response<List<DtoMessage>> GetAllMessages()
        {
            Response<List<DtoMessage>> res = new Response<List<DtoMessage>>();
            var result = (from q in Context.TblMessage.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoMessage
                          {
                              Id = q.Id,
                              Name = q.Name,
                              Email = q.Email,
                              Phone = q.Phone,
                              Message = q.Message
                          }).ToList();


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }
    }
}
