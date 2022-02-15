using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IProductsRepository : IGenericRepository<TblProducts>
    {
        Task<Response<List<DtoProducts>>> GetAllProduct();
        Task<Response<DtoProducts>> AddEditProduct(DtoProducts dtoProducts);
        Response<List<DtoProductGroup>> GetAllProductPerCategory(int type);
        Task<Response<List<DtoProducts>>> SearchProduct(string search, int usertype);
         Response<bool> DeleteProduct(string Ids);
        Response<List<DtoProductsForDrop>> GetAllProductWithColor();
        Response<List<DtoProductsWithColorGroup>> GetAllProductWithColorForShow();
    }
}
