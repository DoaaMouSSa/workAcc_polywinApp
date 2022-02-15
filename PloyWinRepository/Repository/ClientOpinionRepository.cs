using IPloyWinRepository.InterFace;
using Microsoft.EntityFrameworkCore;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using PloyWinRepository.EnumData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinRepository.Repository
{
    public class ClientOpinionRepository : GenericRepository<ApplicationContext, TblClientOpinions>, IClientOpinionRepository
    {
        public Response<DtoClientsOpinions> AddEditClientsOpinion(DtoClientsOpinions dto)
        {
            if (dto != null)
            {
                if (dto.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dto.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        if (dto.Img != null)
                        {
                            isExist.ImgPath = dto.ImgPath;
                        }
                        isExist.Comment = dto.Comment;

                        if (dto.Vid != null)
                        {
                            isExist.VidPath = dto.VidPath;
                        }
                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();

                        dto.ImgPath = isExist.ImgPath;
                        dto.VidPath = isExist.VidPath;
                    }
                }
                else
                {
                    var obj = new TblClientOpinions()
                    {
                        AddedDate = DateTime.Now,
                        Comment = dto.Comment,
                        ImgPath = dto.ImgPath,
                        VidPath = dto.VidPath
                    };

                    Add(obj);
                    Save();

                    dto.Id = obj.Id;
                }
            }

            Response<DtoClientsOpinions> res = new Response<DtoClientsOpinions>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dto;
            return res;
        }

        public Response<bool> DeleteClientsOpinion(string Ids)
        {
            var listId = Ids.Split(',').ToList();

            bool dd = false;

            foreach (var Id in listId)
            {
                var result = FindBy(x => x.Id == Convert.ToInt32(Id)).FirstOrDefault();


                if (result != null)
                {
                    result.IsDeleted = true;
                    result.DeletedDate = DateTime.Now;

                    Edit(result);
                    Save();

                    dd = true;
                }
            }

            Response<bool> res = new Response<bool>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dd;
            return res;
        }

        public Response<List<DtoClientsOpinions>> GetAllClientsOpinion()
        {
            var result = (from q in Context.TblClientOpinions.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoClientsOpinions
                          {
                              Id = q.Id,
                              Comment = q.Comment,
                              ImgPath = q.ImgPath,
                              VidPath = q.VidPath
                          }).ToList();

            Response<List<DtoClientsOpinions>> res = new Response<List<DtoClientsOpinions>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
    }
}
