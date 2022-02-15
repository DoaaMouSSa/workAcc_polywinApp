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
    public class CostCalculationRepository : GenericRepository<ApplicationContext, TblCostCalculation>, ICostCalculationRepository
    {
        private readonly ICostCalculationItemsRepository _items;

        public CostCalculationRepository(ICostCalculationItemsRepository items)
        {
            _items = items;
        }

        public int AddCostCalc(CostCalc dto)
        {
            if (dto != null)
            {
                var obj = new TblCostCalculation()
                {
                    ColorId = dto.colorId,
                    AddedDate = DateTime.Now,
                    expenses = dto.expenses,
                    height = dto.height,
                    mortal = dto.mortal,
                    subCategoryId = dto.subCategoryId,
                    width = dto.Width,
                    net = dto.net
                };

                Add(obj);
                Save();
                dto.Id = obj.Id;
                _items.AddCostCalcItems(obj.Id, dto.CostCalcItems);
            }

            return dto.Id;
        }


        public bool UpdateCostCalcToClient(int? CostCalcId, int? ClientId)
        {
            var isUpdate = false;

            var isExist = FindBy(x => x.Id == CostCalcId).FirstOrDefault();

            if (isExist != null)
            {
                isExist.ClientId = ClientId;

                Edit(isExist);
                Save();

                isUpdate = true;
            }

            return isUpdate;
        }

        public bool DeleteCostCalc(int Id)
        {
            var isUpdate = false;

            var isExist = FindBy(x => x.Id == Id).FirstOrDefault();

            if (isExist != null)
            {
                isExist.IsDeleted = true;
                isExist.DeletedDate = DateTime.Now;

                Edit(isExist);
                Save();

                isUpdate = true;
            }

            return isUpdate;
        }

        public List<CostCalc> GetCostCalcByClientId(int Client)
        {
            var result = (from q in Context.TblCostCalculation.AsNoTracking().Where(x => x.IsDeleted == null && x.ClientId == Client)
                          select new CostCalc
                          {
                              colorName = q.TblColors.ColorName,
                              net = q.net,
                              expenses = q.expenses,
                              height = q.height,
                              colorId = q.ColorId,
                              Id = q.Id,
                              mortal = q.mortal,
                              ClientId = q.ClientId,
                              subCategoryId = q.subCategoryId,
                              subCategoryName = q.TblSubCategory.Name,
                              PathFile = q.TblSubCategory.FilePath,
                              Width = q.width,
                              CostCalcItems = q.TblCostCalculationItems.Select(x =>
                              new CostCalcItems
                              {
                                  cost = x.cost,
                                  descount = x.descount,
                                  meter = x.meter,
                                  productId = x.productId,
                                  totalByDescount = x.totalByDescount,
                                  totalMeterCost = x.totalMeterCost,
                                  typeOfDescount = x.typeOfDescount
                              }).ToList()
                          }).ToList();


            foreach (var item in result)
            {
                if (item.CostCalcItems.Count() > 0)
                {
                    item.totalCalc = item.CostCalcItems.Sum(x => Convert.ToDouble(x.totalByDescount));

                    item.totalCalc += item.mortal;
                    item.totalCalc += item.expenses;
                }
                else
                {
                    item.totalCalc = 0;
                }
            }

            return result;

        }
    }
}
