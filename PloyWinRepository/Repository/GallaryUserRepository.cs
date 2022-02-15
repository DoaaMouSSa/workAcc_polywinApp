using IPloyWinRepository.InterFace;
using Microsoft.EntityFrameworkCore;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinRepository.Repository
{
    public class GallaryUserRepository : GenericRepository<ApplicationContext, TblGallaryUser>, IGallaryUserRepository
    {
        public bool AddGalleryByContract(int? contractId, List<DtoGalleryUser> dto)
        {
            if (dto.Count > 0)
            {
                foreach (var item in dto)
                {
                    var obj = new TblGallaryUser()
                    {
                        AddedDate = DateTime.Now,
                        ContractItemId = contractId,
                        ImgURL = item.PhotoPath
                    };

                    Add(obj);
                    Save();
                }

                return true;
            }
        
           

            return false;
        }

        public List<DtoGalleryUser> GetAllGalleryByContractId(int contractId)
        {
            var result = (from q in Context.TblGallaryUser.AsNoTracking().Where(x => x.ContractItemId == contractId && x.IsDeleted == null)
                          select new DtoGalleryUser
                          {
                              Id = q.Id,
                              PhotoPath = q.ImgURL
                          }).ToList();

            return result;
        }


        public bool DeleteGalleryById(int Id)
        {
            var result = FindBy(x => x.Id == Id).FirstOrDefault();

            if (result != null)
            {
                result.IsDeleted = true;

                Edit(result);
                Save();

                return true;
            }
            return false;
        }
    }
}
