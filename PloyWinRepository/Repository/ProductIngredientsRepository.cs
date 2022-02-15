using IPloyWinRepository.InterFace;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using PloyWinRepository.EnumData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinRepository.Repository
{
    public class ProductIngredientsRepository : GenericRepository<ApplicationContext, TblProductIngredients>, IProductIngredientsRepository
    {
        private readonly ICostCalculationRepository _costCalculation;
        public ProductIngredientsRepository(ICostCalculationRepository costCalculation)
        {
            _costCalculation = costCalculation;
        }


        public Response<List<DtoProductIngredients>> GetAllProductIngredients()
        {
            var result = (from q in Context.TblProductIngredients.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoProductIngredients
                          {
                              Id = q.Id,
                              Equation = q.Equation,
                              ProductId = q.ProductId,
                              ProductName = q.TblProductName.Name,//+ " - " + q.TblProduct.TblColors.ColorName,
                              SubCategoryId = q.SubCategoryId,
                              SubCategoryName = q.TblSubCategory.Name
                          }).ToList();

            foreach (var item in result)
            {
                if (item.Equation != null)
                {
                    item.Equation = item.Equation.Split("Select")[1].Trim();
                }
            }

            Response<List<DtoProductIngredients>> res = new Response<List<DtoProductIngredients>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
        public Response<DtoProductIngredients> AddEditProductIngredient(DtoProductIngredients dto)
        {
            Response<DtoProductIngredients> res = new Response<DtoProductIngredients>();

            if (dto != null)
            {
                if (dto.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dto.Id).FirstOrDefault();
                    if (isExist != null)
                    {
                        isExist.Equation = "Select  " + dto.Equation;
                        isExist.ModifiedDate = DateTime.Now;
                        isExist.SubCategoryId = dto.SubCategoryId;
                        isExist.ProductId = dto.ProductId;


                        Edit(isExist);
                        Save();
                        dto.ProductName = Context.TblProductName.AsNoTracking().Where(x => x.Id == dto.ProductId).FirstOrDefault().Name;

                        // dto.ProductName = Context.TblProducts.AsNoTracking().Where(x => x.Id == dto.ProductId).FirstOrDefault().TblProductName.Name;
                    }
                }

                else
                {
                    var obj = new TblProductIngredients()
                    {
                        AddedDate = DateTime.Now,
                        Equation = "Select  " + dto.Equation,
                        SubCategoryId = dto.SubCategoryId,
                        ProductId = dto.ProductId
                    };

                    Add(obj);
                    Save();
                    dto.Id = obj.Id;
                    //var productId = Context.TblProducts.AsNoTracking().Where(x => x.Id == dto.ProductId).FirstOrDefault().ProductId;
                    dto.ProductName = Context.TblProductName.AsNoTracking().Where(x => x.Id == dto.ProductId).FirstOrDefault().Name;

                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dto;
            return res;
        }
        public Response<bool> DeleteProductIngredient(string Ids)
        {
            var listId = Ids.Split(',').ToList();

            bool result = false;

            foreach (var Id in listId)
            {
                var isExist = FindBy(x => x.Id == Convert.ToInt32(Id)).FirstOrDefault();


                if (isExist != null)
                {
                    isExist.IsDeleted = true;
                    isExist.DeletedDate = DateTime.Now;

                    Edit(isExist);
                    Save();

                    result = true;
                }
            }

            Response<bool> res = new Response<bool>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
        public Response<List<DtoProductIngredients>> GetProductIngredientsBySubCat(int id)
        {
            Response<List<DtoProductIngredients>> res = new Response<List<DtoProductIngredients>>();

            var result = (from q in Context.TblProductIngredients.AsNoTracking().Where(x => x.IsDeleted == null && x.SubCategoryId == id)
                          select new DtoProductIngredients
                          {
                              Id = q.Id,
                              ProductId = q.ProductId,
                              ProductName = q.TblProductName.Name, //+ " - " + q.TblProduct.TblColors.ColorName,
                              Equation = q.Equation
                          }).ToList();


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
        public Response<List<DtoProductIngredients>> GetProductIngredientsByProduct(int id)
        {
            Response<List<DtoProductIngredients>> res = new Response<List<DtoProductIngredients>>();

            var result = (from q in Context.TblProductIngredients.AsNoTracking().Where(x => x.IsDeleted == null && x.ProductId == id)
                          select new DtoProductIngredients
                          {
                              Id = q.Id,
                              Equation = q.Equation
                          }).ToList();


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
        public string GetNewCalcProduct(int productId, string width, string height)
        {
            using (SqlConnection conn = new SqlConnection("Server=SQL5102.site4now.net;Database=db_a7769c_mamsre;User Id=db_a7769c_mamsre_admin;password=Aa@123Ee@123;Trusted_Connection=False;MultipleActiveResultSets=true;"))
            using (SqlCommand cmd = new SqlCommand("getExuationOfProduct", conn))
            {
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapt.SelectCommand.Parameters.Add(new SqlParameter("@productId", SqlDbType.Int));
                adapt.SelectCommand.Parameters["@productId"].Value = productId;
                adapt.SelectCommand.Parameters.Add(new SqlParameter("@width", SqlDbType.NVarChar, 30));
                adapt.SelectCommand.Parameters["@width"].Value = width;
                adapt.SelectCommand.Parameters.Add(new SqlParameter("@height", SqlDbType.NVarChar, 30));
                adapt.SelectCommand.Parameters["@height"].Value = height;


                // fill the data table - no need to explicitly call `conn.Open()` - 
                // the SqlDataAdapter automatically does this (and closes the connection, too)
                DataTable dt = new DataTable();
                adapt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }

                return "";
            }
        }
        public ProductCost GetTotalPriceWithItems(DtoProductCost dto, int? userType)
        {
            
            CostCalc calc = new CostCalc();
            ProductCost pro = new ProductCost();

            calc.colorId = dto.colorId;
            calc.expenses = dto.expenses;
            calc.height = dto.height;
            calc.subCategoryId = dto.subCategoryId;
            calc.Width = dto.Width;

            //جلب بيانات القطع بناءا على المنتج
            var itemList = FindBy(x => x.SubCategoryId == dto.subCategoryId && x.IsDeleted == null).ToList();

            pro.items = new List<ItemCost>();
            calc.CostCalcItems = new List<CostCalcItems>();

            foreach (var item in itemList)
            {
                ItemCost items = new ItemCost();
                CostCalcItems calcItems = new CostCalcItems();

                // عرض كل منتج بيخرج كام متر
                var totalMeter = GetNewCalcProduct(item.ProductId, dto.Width, dto.height);

                // تكلفة المتر
                var totalCostMeter = Context.TblProducts.AsNoTracking().Where(x => x.ProductId == item.ProductId && x.ColorId == dto.colorId && x.IsDeleted == null).Select(x =>
                new
                {
                    ProductId = x.ProductId,
                    PricePerMeter = x.PricePerMeter,
                    CategoryId = x.CategoryId
                }).FirstOrDefault();

                if (totalCostMeter != null)
                {
                    var productName = Context.TblProductName.AsNoTracking().Where(x => x.Id == totalCostMeter.ProductId).FirstOrDefault().Name;

                    items.ProductId = item.ProductId;
                    items.ProductName = productName;
                    items.Meter = totalMeter;
                    items.Cost = totalCostMeter.PricePerMeter.ToString();
                    items.TotalMeterCost = Math.Round((double)(Convert.ToDouble(totalCostMeter.PricePerMeter) * Convert.ToDouble(totalMeter)), 2).ToString();

                    calcItems.productId = item.ProductId;
                    calcItems.cost = items.Cost;
                    calcItems.meter = items.Meter;
                    calcItems.totalMeterCost = items.TotalMeterCost;

                    var getParentCtegory = Context.TblCategory.AsNoTracking().Where(x => x.Id == totalCostMeter.CategoryId).FirstOrDefault().TypeOfCategory;

                    var getDescount = Context.TblDescount.AsNoTracking().Where(x => x.TypeOfCategory == getParentCtegory && x.IsDeleted == null && x.TypeOfDescount == userType).Select(x => new
                    {
                        Descount = x.Descount,
                        typeofdescount = x.TypeDescount
                    }).FirstOrDefault();

                    if (getDescount != null)
                    {
                        items.Descount = getDescount.Descount.ToString();
                        calcItems.descount = items.Descount;

                        if (getDescount.typeofdescount == true)
                        {
                            var deco = (((Convert.ToDouble(items.TotalMeterCost) * Convert.ToDouble(getDescount.Descount)) / 100)).ToString();

                            var XX = Convert.ToDouble(items.TotalMeterCost) - Convert.ToDouble(deco);
                            XX = Math.Round(XX, 2);
                            items.TotalByDescount = (XX).ToString();
                            calcItems.totalByDescount = items.TotalByDescount;
                        }
                        else
                        {
                            var XX = Convert.ToDouble(items.TotalMeterCost) - Convert.ToDouble(getDescount.Descount);
                            XX = Math.Round(XX, 2);
                            items.TotalByDescount = (XX).ToString();
                            calcItems.totalByDescount = items.TotalByDescount;
                        }

                        items.TypeOfDescount = getDescount.typeofdescount == true ? "نسبة مئوية" : "رقم صحيح";
                        calcItems.typeOfDescount = items.TypeOfDescount;

                        items.Type = true;
                        pro.items.Add(items);
                        calc.CostCalcItems.Add(calcItems);
                    }
                    else
                    {
                        items.Descount = "0";
                        items.TypeOfDescount = "لا يوجد خصم";
                        items.TotalByDescount = items.TotalMeterCost;

                        calcItems.typeOfDescount = items.TypeOfDescount;
                        calcItems.totalByDescount = items.TotalByDescount;
                        items.Type = true;
                        pro.items.Add(items);
                        calc.CostCalcItems.Add(calcItems);
                    }
                }
            }


            //قائمة منتجات اكسسوارات
            var listAcces = Context.TblProductIngredientAccessory.AsNoTracking().Where(x => x.SubCategoryId == dto.subCategoryId && x.IsDeleted == null).ToList();

            foreach (var item in listAcces)
            {
                ItemCost items = new ItemCost();
                CostCalcItems calcItems = new CostCalcItems();

                // تكلفة المتر
                var totalCostMeter = Context.TblProducts.AsNoTracking().Where(x => x.ProductId == item.ProductId && x.IsDeleted == null).Select(x =>
              new
              {
                  ProductId = x.ProductId,
                  PricePerOne = x.PricePerOne,
                  CategoryId = x.CategoryId
              }).FirstOrDefault();

                if (totalCostMeter != null)
                {
                    var productName = Context.TblProductName.AsNoTracking().Where(x => x.Id == totalCostMeter.ProductId).FirstOrDefault().Name;

                    items.ProductId = item.ProductId;
                    items.ProductName = productName;
                    items.Meter = "0";
                    items.Cost = totalCostMeter.PricePerOne.ToString();
                    items.TotalMeterCost = Math.Round((double)(Convert.ToDouble(totalCostMeter.PricePerOne) * Convert.ToDouble(item.CountOfItems)), 2).ToString();

                    calcItems.productId = item.ProductId;
                    calcItems.cost = items.Cost;
                    calcItems.meter = items.Meter;
                    calcItems.totalMeterCost = items.TotalMeterCost;

                    var getParentCtegory = Context.TblCategory.AsNoTracking().Where(x => x.Id == totalCostMeter.CategoryId).FirstOrDefault().TypeOfCategory;

                    var getDescount = Context.TblDescount.AsNoTracking().Where(x => x.Id == getParentCtegory && x.IsDeleted == null && x.TypeOfDescount == 3).Select(x => new
                    {
                        Descount = x.Descount,
                        typeofdescount = x.TypeDescount
                    }).FirstOrDefault();

                    if (getDescount != null)
                    {
                        items.Descount = getDescount.Descount.ToString();
                        calcItems.descount = items.Descount;

                        if (getDescount.typeofdescount == true)
                        {
                            var deco = (((Convert.ToDouble(items.TotalMeterCost) * Convert.ToDouble(getDescount.Descount)) / 100)).ToString();

                            var XX = Convert.ToDouble(items.TotalMeterCost) - Convert.ToDouble(deco);
                            XX = Math.Round(XX, 2);
                            items.TotalByDescount = (XX).ToString();
                            //items.TotalByDescount = (Math.Round(Convert.ToDouble(items.TotalMeterCost) - Convert.ToDouble(deco)), 2).ToString();
                            calcItems.totalByDescount = items.TotalByDescount;

                        }
                        else
                        {
                            var XX = Convert.ToDouble(items.TotalMeterCost) - Convert.ToDouble(getDescount.Descount);
                            XX = Math.Round(XX, 2);
                            items.TotalByDescount = (XX).ToString();

                            //items.TotalByDescount = (Math.Round(Convert.ToDouble(items.TotalMeterCost) - Convert.ToDouble(getDescount.Descount)), 2).ToString();
                            calcItems.totalByDescount = items.TotalByDescount;

                        }

                        items.TypeOfDescount = getDescount.typeofdescount == true ? "نسبة مئوية" : "رقم صحيح";
                        calcItems.typeOfDescount = items.TypeOfDescount;
                        items.Type = false;
                        pro.items.Add(items);
                        calc.CostCalcItems.Add(calcItems);
                    }
                    else
                    {
                        items.TypeOfDescount = "لا يوجد خصم";

                        items.Descount = "0";

                        items.TotalByDescount = items.TotalMeterCost;

                        calcItems.typeOfDescount = items.TypeOfDescount;
                        calcItems.totalByDescount = items.TotalByDescount;

                        items.Type = false;
                        pro.items.Add(items);
                        calc.CostCalcItems.Add(calcItems);
                    }
                }
            }

            //مجموع نسبة الخصم
            double? totalTypetrue = pro.items.Where(x => x.Type == true).Sum(x => Convert.ToDouble(x.TotalByDescount));

            pro.totalCost = pro.items.Sum(x => Convert.ToDouble(x.TotalByDescount));
            //  calc.totalCalc  = pro.items.Sum(x => Convert.ToDouble(x.TotalByDescount));

            double mortal = dto.mortal ?? 15;

            double totalWithMortal = 0;

            if (mortal > 0)
            {
                totalWithMortal = (double)((totalTypetrue * mortal) / 100);
            }

            //نسبة الربح
            double Net = 0;
            if (dto.net > 0)
            {
                Net = (double)((pro.totalCost * dto.net) / 100);
            }
            
            pro.totalCost += Net;
            pro.totalCost += totalWithMortal;
            pro.totalCost += dto.expenses;
            pro.totalExpenses = Math.Round((double)dto.expenses, 2);
            pro.totalMortal = Math.Round((double)totalWithMortal, 2);
            pro.net = Math.Round((double)Net, 2);
            calc.totalCalc = Math.Round((double)pro.totalCost, 2);
            calc.expenses = Math.Round((double)pro.totalExpenses, 2);
            calc.mortal = Math.Round((double)pro.totalMortal, 2);
            calc.net = Net;

            pro.totalCost = Math.Round((double)pro.totalCost, 2);

            pro.CostCalcId = _costCalculation.AddCostCalc(calc);

            return pro;
        }
    }
}
