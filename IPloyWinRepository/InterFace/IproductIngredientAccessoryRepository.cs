using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IproductIngredientAccessoryRepository:IGenericRepository<TblProductIngredientAccessory>
    {
        Response<List<DtoProductIngredientAccessory>> GetAllProductIngredientAccessory();
        Response<DtoProductIngredientAccessory> AddEditProductIngredientAccessory(DtoProductIngredientAccessory dto);
        Response<bool> DeleteProductIngredientAccessory(string Ids);
        Response<List<DtoProductIngredientAccessory>> GetProductIngredientAccessoryBySubCat(int id);
        Response<List<DtoProductIngredientAccessory>> GetProductIngredientAccessoryByProduct(int id);
    }
}
