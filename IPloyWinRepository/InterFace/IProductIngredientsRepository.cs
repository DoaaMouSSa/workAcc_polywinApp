using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IProductIngredientsRepository : IGenericRepository<TblProductIngredients>
    {
        Response<List<DtoProductIngredients>> GetAllProductIngredients();
        Response<DtoProductIngredients> AddEditProductIngredient(DtoProductIngredients dto);
        Response<bool> DeleteProductIngredient(string Ids);
        Response<List<DtoProductIngredients>> GetProductIngredientsBySubCat(int id);
        Response<List<DtoProductIngredients>> GetProductIngredientsByProduct(int id);
        //Task<string> GetCalcProduct(int productId, string width, string height);
        string GetNewCalcProduct(int productId, string width, string height);
        ProductCost GetTotalPriceWithItems(DtoProductCost dto, int? userType);
    }
}
