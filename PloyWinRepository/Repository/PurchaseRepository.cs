using IPloyWinRepository.InterFace;
using Microsoft.EntityFrameworkCore;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using PloyWinRepository.EnumData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinRepository.Repository
{
    public class PurchaseRepository: GenericRepository<ApplicationContext, TblPurchase>, IPurchaseRepository
    {
        public async Task<Response<DtoPurchase>> AddEditPurchase(DtoPurchase dtoPurchase)
        {
            if (dtoPurchase != null)
            {
                if (dtoPurchase.id > 0)
                {
                    var isExist = FindBy(x => x.Id == dtoPurchase.id).FirstOrDefault();

                    if (isExist != null)
                    {

                        if (dtoPurchase.product_id != 0)
                        {
                            isExist.ProuctId = dtoPurchase.product_id;
                        }
                        if (dtoPurchase.supplier_id != 0)
                        {
                            isExist.SupplierId = dtoPurchase.supplier_id;
                        }
                        if (dtoPurchase.Currency_id != 0)
                        {
                            isExist.CurrencyId = dtoPurchase.Currency_id;
                        }
                        if (dtoPurchase.unit_id != 0)
                        {
                            isExist.ItemTypeId = dtoPurchase.unit_id;
                        }

                        if (dtoPurchase.qty != 0)
                        {
                            isExist.qty = dtoPurchase.qty;
                        }
                        if (dtoPurchase.priceForOnePiece != 0)
                        {
                            isExist.priceForOnePiece = dtoPurchase.priceForOnePiece;
                        }
                        if (dtoPurchase.NumberOfPieces != 0)
                        {
                            isExist.NumberOfPieces = dtoPurchase.NumberOfPieces;
                        }
                        if (dtoPurchase.PriceOfAllPieces != 0)
                        {
                            isExist.PriceOfAllPieces = dtoPurchase.PriceOfAllPieces;
                        }
                        if (dtoPurchase.totalPrice_purchase != 0)
                        {
                            isExist.totalPrice_purchase = dtoPurchase.totalPrice_purchase;
                        }

                        isExist.ModifiedDate = DateTime.Now;
                        Edit(isExist);
                        Save();
                        dtoPurchase.id = isExist.Id;
                        dtoPurchase.product_id = isExist.ProuctId;
                        dtoPurchase.supplier_id = isExist.SupplierId;
                        dtoPurchase.Currency_id = isExist.CurrencyId;
                        dtoPurchase.unit_id = isExist.ItemTypeId;
                        dtoPurchase.priceForOnePiece = isExist.priceForOnePiece;
                        dtoPurchase.PriceOfAllPieces = isExist.PriceOfAllPieces;
                        dtoPurchase.NumberOfPieces = isExist.NumberOfPieces;
                        dtoPurchase.qty = isExist.qty;
                        dtoPurchase.totalPrice_purchase = isExist.totalPrice_purchase;
                    }
                }
                else
                {
                    var objProInv = new TblPurchase()
                    {
                        //add
                        AddedDate = DateTime.Now,
                        ProuctId = dtoPurchase.product_id,
                        SupplierId=dtoPurchase.supplier_id,
                        CurrencyId = dtoPurchase.Currency_id,
                        ItemTypeId = dtoPurchase.unit_id,
                        priceForOnePiece = dtoPurchase.priceForOnePiece,
                        NumberOfPieces = dtoPurchase.NumberOfPieces,
                        PriceOfAllPieces = dtoPurchase.PriceOfAllPieces,
                        qty = dtoPurchase.qty,
                        totalPrice_purchase = dtoPurchase.totalPrice_purchase
                    };
                    Add(objProInv);
                    //decrease balance
                    BanqueRepository bank = new BanqueRepository();
                    await bank.EditBalance(2, Convert.ToInt16(dtoPurchase.totalPrice_purchase));
                    //increase store
                    //search if product is exist
                    var product = Context.TblStores.FirstOrDefault(p => p.ProductIdName == dtoPurchase.product_id);
                    if (product == null)
                    {
                        DtoStoreFromPurchase dtoProduct = new DtoStoreFromPurchase()
                        {
                            productname_id = (int)dtoPurchase.product_id,
                            quantity = dtoPurchase.qty
                        };
                        StoreRepository store = new StoreRepository();
                        store.AddProductToStoreAfterPurchase(dtoProduct);
                    }
                    else
                    {
                        product.Quantity += dtoPurchase.qty;
                    }
                    Save();
                }
            }
            Response<DtoPurchase> res = new Response<DtoPurchase>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dtoPurchase;
            return res;
        }

          public async Task<Response<bool>> DeletePurchase(string Ids)
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

         public async Task<Response<List<DtoPurchaseForShow>>> getPurchase()
          {
            var result = (from q in Context.TblPurchase.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoPurchaseForShow
                          {
                              id = q.Id,
                              productId = q.TblProductName.Id,
                              productName = q.TblProductName.Name,
                              supplierId = q.TblSupplier.Id,
                              supplierName = q.TblSupplier.Name,
                              CurrencyId = q.TblCurrency.Id,
                              CurrencyName = q.TblCurrency.Name,
                              ItemtypeId = q.TblItemType.Id,
                              nameItemType = q.TblItemType.NameItemType,
                              priceForOnePiece = q.priceForOnePiece,
                              PriceOfAllPieces=q.PriceOfAllPieces,
                              NumberOfPieces=q.NumberOfPieces,
                                qty = q.qty,
                              totalPrice_purchase = q.totalPrice_purchase,
                              Added_Date=q.AddedDate.GetValueOrDefault().ToString("dd-MMMM-yyyy", new CultureInfo("ar-AE")),
                          }).ToList();
        Response<List<DtoPurchaseForShow>> res = new Response<List<DtoPurchaseForShow>>();

        res.code = StaticApiStatus.ApiSuccess.Code;
              res.message = StaticApiStatus.ApiSuccess.MessageAr;
              res.status = StaticApiStatus.ApiSuccess.Status;
              res.IsSuccess = true;
              res.payload = result;

              return res;
          }
}
}
