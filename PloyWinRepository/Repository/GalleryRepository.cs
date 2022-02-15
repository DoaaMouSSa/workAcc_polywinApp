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
    public class GalleryRepository : GenericRepository<ApplicationContext, TblGallery>, IGalleryRepository
    {
        public async Task<Response<List<DtoGalleryGroup>>> GetAllAgent(int type)
        {
            Response<List<DtoGalleryGroup>> res = new Response<List<DtoGalleryGroup>>();
            List<DtoGalleryGroup> group = new List<DtoGalleryGroup>();
            //var result = new List<DtoGallery>();
            var listGallery = (from q in Context.TblGallery.AsNoTracking().Where(x => x.IsDeleted == null && x.TypeGallery == type)
                               select new DtoGallery
                               {
                                   Id = q.Id,
                                   CategoryName = q.TblCategoryChildGallery.CategoryChildName,
                                   ImagePath = q.ImageGallery
                               }).ToList();

            if (listGallery.Count() > 0)
            {
                var groupByCategory = from prod in listGallery
                                      group prod by prod.CategoryName
                                                           into egroup
                                      orderby egroup.Key
                                      select new
                                      {
                                          CategoryName = egroup.Key,
                                          ListImages = egroup.ToList()
                                      };


                foreach (var item in groupByCategory)
                {
                    DtoGalleryGroup gg = new DtoGalleryGroup();

                    gg.CategoryName = item.CategoryName;
                    gg.listGallery = new List<DtoGalleryList>();

                    foreach (var gallery in item.ListImages)
                    {
                        DtoGalleryList dto = new DtoGalleryList();

                        dto.Id = gallery.Id;
                        dto.GalleryImage = gallery.ImagePath;

                        gg.listGallery.Add(dto);
                    }

                    group.Add(gg);
                }
            }
            else
            {
                #region staticFile
                var result = new List<DtoGallery>()
                {
                    new DtoGallery
                    {
                    CategoryName ="إكسسوارات",
                    ListImages = new string[68] {
                    "Accessories/مقبض خارجي كبير.png", "Accessories/مقبض بارزسوبر.png",
                    "Accessories/مقبض اشاره كبير.png","Accessories/وش باب كبير 1.jpg",
                    "Accessories/وش باب صغير.jpg","Accessories/مقبض سلك معدن.jpg",
                    "Accessories/مقبض دبل هاند.jpg","Accessories/مقبض خارجي كامل.jpg",
                    "Accessories/مقبض خارجي صغير كامل.jpg","Accessories/مقبض بمفتاح.jpg",
                    "Accessories/مقبض بارز.jpg","Accessories/مقبض اشاره كامل كبير.jpg",
                    "Accessories/مقبض اشاره صغير كامل.jpg","Accessories/مقبض اشارة كامل بكالون.jpg",
                    "Accessories/مفصله 9.5.jpg","Accessories/مفصله 7.5.jpg",
                    "Accessories/مسمار مولين.jpg","Accessories/مسمار تركي.jpg",
                    "Accessories/محبس مفصلي 2 درفه.jpg","Accessories/محبس جرار.jpg",
                    "Accessories/محبس 1درفه.jpg","Accessories/كالون خارجي كبير.jpg",
                    "Accessories/كالون خاجي اقتصادي.jpg","Accessories/كالون اشاره اقتصادي.jpg",
                    "Accessories/كالون اشارة كبير.jpg","Accessories/غاطس معدن.jpg",
                    "Accessories/عجل سنجل معدن.jpg","Accessories/عجل سنجل بلاستيك.jpg",
                    "Accessories/عجل سنجل اقتصادي.jpg","Accessories/عجل سلك.jpg",
                    "Accessories/عجل دبل معدن.jpg","Accessories/عجل دبل بلاستيك.jpg",
                    "Accessories/عجل دبل اقتصادي.jpg","Accessories/عجل حفر معدن.jpg",
                    "Accessories/عجل حفر بلاستيك.jpg","Accessories/سلندر.jpg",
                    "Accessories/سكاك مفصلي شنكوتي.jpg","Accessories/سبليونه مفصلي.jpg",
                    "Accessories/سبليونه كالون1.jpg","Accessories/سبليونه شييش.jpg",
                    "Accessories/سبليونه شيش.jpg","Accessories/سبليونه جرار.jpg",
                    "Accessories/سبليونه بكالون.jpg","Accessories/سبليونه بديل ترباس.jpg",
                    "Accessories/سبليونه اقتصادي.jpg","Accessories/دبل هاند بمفتاح.jpg",
                    "Accessories/خشخان مفصلي.jpg","Accessories/ترباس بوكلير كبير.jpg",
                    "Accessories/ترباس بوكلير صغير.jpg","Accessories/TTS002.jpg",
                    "Accessories/TTS001.jpg","Accessories/TTS000.jpg",
                    "Accessories/PLK170-01.jpg","Accessories/MNT140-07.jpg",
                    "Accessories/MNT140-06.jpg","Accessories/MNT140-05.jpg",
                    "Accessories/MNT140-03.jpg","Accessories/MNT140-01.jpg",
                    "Accessories/MKS110-00.jpg","Accessories/KE13004.jpg",
                    "Accessories/ISP100-7.jpg","Accessories/APK150-01.jpg",
                    "Accessories/AP005 مقبض  بارز.jpg","Accessories/ALT160-01.jpg",
                    "Accessories/AK120-06.jpg","Accessories/AK120-01.jpg",
                    "Accessories/AA004.jpg","Accessories/3D مفصله.jpg"}
                    },
                    new DtoGallery
                    {
                    CategoryName = "شبابيك",
                    ListImages = new string[189]
                    {
                    "Window/1.jpg","Window/2.jpg","Window/3.jpg","Window/4.jpg","Window/5.jpg",
                    "Window/6.jpg","Window/7.jpg","Window/8.jpg","Window/9.jpg","Window/10.jpg",
                    "Window/11.jpg","Window/12.jpg","Window/13.jpg","Window/14.jpg","Window/15.jpg",
                    "Window/16.jpg","Window/17.jpg","Window/18.jpg","Window/19.jpg","Window/20.jpg",
                    "Window/21.jpg","Window/22.jpg","Window/23.jpg","Window/24.jpg","Window/25.jpg",
                    "Window/26.jpg","Window/27.jpg","Window/28.jpg","Window/29.jpg","Window/30.jpg",
                    "Window/31.jpg","Window/32.jpg","Window/33.jpg","Window/34.jpg","Window/35.jpg",
                    "Window/36.jpg","Window/37.jpg","Window/38.jpg","Window/39.jpg","Window/40.jpg",
                    "Window/41.jpg","Window/42.jpg","Window/43.jpg","Window/44.jpg","Window/45.jpg",
                    "Window/46.jpg","Window/47.jpg","Window/48.jpg","Window/49.jpg","Window/50.jpg",
                    "Window/51.jpg","Window/52.jpg","Window/53.jpg","Window/54.jpg","Window/55.jpg",
                    "Window/56.jpg","Window/57.jpg","Window/58.jpg","Window/59.jpg","Window/60.jpg",
                    "Window/61.jpg","Window/62.jpg","Window/63.jpg","Window/64.jpg","Window/65.jpg",
                    "Window/66.jpeg","Window/67.jpeg","Window/68.jpeg","Window/69.jpeg","Window/70.jpeg",
                    "Window/71.jpeg","Window/72.jpeg","Window/73.jpeg","Window/74.jpeg","Window/75.jpeg",
                    "Window/76.jpeg","Window/77.jpeg","Window/78.jpeg",
                    "Window/79.jpeg","Window/80.jpeg","Window/81.jpeg","Window/82.jpeg","Window/83.jpeg","Window/84.jpeg",
                    "Window/85.jpeg","Window/86.jpeg","Window/87.jpeg","Window/88.jpeg","Window/89.jpeg","Window/90.jpeg",
                    "Window/91.jpeg","Window/92.jpeg","Window/93.jpeg","Window/94.jpeg","Window/95.jpeg","Window/96.jpeg",
                    "Window/97.jpeg","Window/98.jpeg","Window/99.jpeg","Window/100.jpeg","Window/101.jpeg","Window/102.jpeg",
                    "Window/103.jpeg","Window/104.jpeg","Window/105.jpeg","Window/106.jpeg","Window/107.jpeg","Window/108.jpeg",
                    "Window/109.jpeg","Window/110.jpeg","Window/111.jpeg","Window/112.jpeg","Window/113.jpeg","Window/114.jpeg",
                    "Window/115.jpeg","Window/116.jpeg","Window/117.jpeg","Window/118.jpeg","Window/119.jpeg","Window/120.jpeg",
                    "Window/121.jpeg","Window/122.jpeg","Window/123.jpeg","Window/124.jpeg","Window/125.jpeg","Window/126.jpeg",
                    "Window/127.jpeg","Window/128.jpeg","Window/129.jpeg","Window/130.jpeg","Window/131.jpeg","Window/132.jpeg",
                    "Window/133.jpeg","Window/134.jpeg","Window/135.jpeg","Window/136.jpeg","Window/137.jpeg","Window/138.jpeg",
                    "Window/139.jpeg","Window/140.jpeg","Window/141.jpeg","Window/142.jpeg","Window/143.jpeg","Window/144.jpeg",
                    "Window/145.jpeg","Window/146.jpeg","Window/147.jpeg","Window/148.jpeg","Window/149.jpeg","Window/150.jpeg",
                    "Window/151.jpeg","Window/152.jpeg","Window/153.jpeg","Window/154.jpeg","Window/155.jpeg","Window/156.jpeg",
                    "Window/157.jpeg","Window/158.jpeg","Window/159.jpeg","Window/160.jpeg","Window/161.jpeg","Window/162.jpeg",
                    "Window/163.jpeg","Window/164.jpeg","Window/165.jpeg","Window/166.jpeg","Window/167.jpeg","Window/168.jpeg",
                    "Window/169.jpeg","Window/170.jpeg","Window/171.jpeg","Window/172.jpeg","Window/173.jpeg","Window/174.jpeg","Window/175.jpeg",
                    "Window/176.jpeg","Window/177.jpeg","Window/178.jpeg","Window/179.jpeg","Window/180.jpeg","Window/181.jpeg","Window/182.jpeg",
                    "Window/183.jpeg","Window/184.jpeg","Window/185.jpeg","Window/186.jpeg","Window/187.jpeg","Window/188.jpeg",
                    "Window/189.jpeg"
                    }
                    },
                    new DtoGallery
                    {
                    CategoryName = "أبواب",
                    ListImages = new string[168]
                    {
                    "Doors/1.jpg","Doors/2.jpg","Doors/3.jpg","Doors/4.jpg","Doors/5.jpg",
                    "Doors/6.jpg","Doors/7.jpg","Doors/8.jpg","Doors/9.jpg","Doors/10.jpg",
                    "Doors/11.jpg","Doors/12.jpg","Doors/13.jpg","Doors/14.jpg","Doors/15.jpg",
                    "Doors/16.jpg","Doors/17.jpg","Doors/18.jpg","Doors/19.jpg","Doors/20.jpg",
                    "Doors/21.jpg","Doors/22.jpg","Doors/23.jpg","Doors/24.jpg","Doors/25.jpg",
                    "Doors/26.jpg","Doors/27.jpg","Doors/28.jpg","Doors/29.jpg","Doors/30.jpg",
                    "Doors/31.jpg","Doors/32.jpg","Doors/33.jpg","Doors/34.jpg","Doors/35.jpg",
                    "Doors/36.jpg","Doors/37.jpg","Doors/38.jpg","Doors/39.jpg","Doors/40.jpg",
                    "Doors/41.jpg","Doors/42.jpg","Doors/43.jpg","Doors/44.jpg","Doors/45.jpg",
                    "Doors/46.jpg","Doors/47.jpg","Doors/48.jpg","Doors/49.jpg","Doors/50.jpg",
                    "Doors/51.jpg","Doors/52.jpg","Doors/53.jpg","Doors/54.jpg","Doors/55.jpg",
                    "Doors/56.jpg","Doors/57.jpg","Doors/58.jpeg","Doors/59.jpeg","Doors/60.jpeg",
                    "Doors/61.jpeg","Doors/62.jpeg","Doors/63.jpeg","Doors/64.jpeg","Doors/65.jpeg",
                    "Doors/66.jpeg","Doors/67.jpeg","Doors/68.jpeg","Doors/69.jpeg","Doors/70.jpeg",
                    "Doors/71.jpeg","Doors/72.jpeg","Doors/73.jpeg","Doors/74.jpeg","Doors/75.jpeg",
                    "Doors/76.jpeg","Doors/77.jpeg","Doors/78.jpeg",
                    "Doors/79.jpeg","Doors/80.jpeg","Doors/81.jpeg","Doors/82.jpeg","Doors/83.jpeg","Doors/84.jpeg",
                    "Doors/85.jpeg","Doors/86.jpeg","Doors/87.jpeg","Doors/88.jpeg","Doors/89.jpeg","Doors/90.jpeg",
                    "Doors/91.jpeg","Doors/92.jpeg","Doors/93.jpeg","Doors/94.jpeg","Doors/95.jpeg","Doors/96.jpeg",
                    "Doors/97.jpeg","Doors/98.jpeg","Doors/99.jpeg","Doors/100.jpeg","Doors/101.jpeg","Doors/102.jpeg",
                    "Doors/103.jpeg","Doors/104.jpeg","Doors/105.jpeg","Doors/106.jpeg","Doors/107.jpeg","Doors/108.jpeg",
                    "Doors/109.jpeg","Doors/110.jpeg","Doors/111.jpeg","Doors/112.jpeg","Doors/113.jpeg","Doors/114.jpeg",
                    "Doors/115.jpeg","Doors/116.jpeg","Doors/117.jpeg","Doors/118.jpeg","Doors/119.jpeg","Doors/120.jpeg",
                    "Doors/121.jpeg","Doors/122.jpeg","Doors/123.jpeg","Doors/124.jpeg","Doors/125.jpeg","Doors/126.jpeg",
                    "Doors/127.jpeg","Doors/128.jpeg","Doors/129.jpeg","Doors/130.jpeg","Doors/131.jpeg","Doors/132.jpeg",
                    "Doors/133.jpeg","Doors/134.jpeg","Doors/135.jpeg","Doors/136.jpeg","Doors/137.jpeg","Doors/138.jpeg",
                    "Doors/139.jpeg","Doors/140.jpeg","Doors/141.jpeg","Doors/142.jpeg","Doors/143.jpeg","Doors/144.jpeg",
                    "Doors/145.jpeg","Doors/146.jpeg","Doors/147.jpeg","Doors/148.jpeg","Doors/149.jpeg","Doors/150.jpeg",
                    "Doors/151.jpeg","Doors/152.jpeg","Doors/153.jpeg","Doors/154.jpeg","Doors/155.jpeg","Doors/156.jpeg",
                    "Doors/157.jpeg","Doors/158.jpeg","Doors/159.jpeg","Doors/160.jpeg","Doors/161.jpeg","Doors/162.jpeg",
                    "Doors/163.jpeg","Doors/164.jpeg","Doors/165.jpeg","Doors/166.jpeg","Doors/167.jpeg","Doors/168.jpeg"
                    }
                    },
                    new DtoGallery
                    {
                    CategoryName = "اقتصادى",
                    ListImages = new string[54]
                    {
                    "economic/1.jpeg","economic/2.jpeg","economic/3.jpeg","economic/4.jpeg","economic/5.jpeg",
                    "economic/6.jpeg","economic/7.jpg","economic/8.jpg","economic/9.jpg","economic/10.jpg",
                    "economic/11.jpg","economic/12.jpg","economic/13.jpg","economic/14.jpg","economic/15.jpg",
                    "economic/16.png","economic/17.png","economic/18.png","economic/19.png","economic/20.png",
                    "economic/21.png","economic/22.png","economic/23.png","economic/24.png","economic/25.png",
                    "economic/26.png","economic/27.png","economic/28.png","economic/29.png","economic/30.png",
                    "economic/31.png","economic/32.png","economic/33.png","economic/34.png","economic/35.png",
                    "economic/36.png","economic/37.png","economic/38.png","economic/39.png","economic/40.png",
                    "economic/41.png","economic/42.png","economic/43.png","economic/44.png","economic/45.png",
                    "economic/46.png","economic/47.png","economic/48.png","economic/49.png","economic/50.png",
                    "economic/51.png","economic/52.png","economic/53.png","economic/41.png"
                    }
                    },
                    new DtoGallery
                    {
                        CategoryName="ماكينات",
                        ListImages = new string[36]
                        {
                        "machine/1.png","machine/2.png","machine/3.png","machine/4.png","machine/5.jpeg",
                        "machine/6.jpg","machine/7.jpg","machine/8.jpg","machine/9.jpg","machine/10.jpg",
                        "machine/11.jpg","machine/12.jpg","machine/13.jpg","machine/14.jpg","machine/15.jpg",
                        "machine/16.jpg","machine/17.jpg","machine/18.jpg","machine/19.jpg","machine/20.jpg",
                        "machine/21.jpg","machine/22.jpg","machine/23.jpg","machine/24.jpg","machine/25.jpg",
                        "machine/26.jpg","machine/27.jpg","machine/28.jpg","machine/29.jpg","machine/30.jpg",
                        "machine/31.jpg","machine/32.jpg","machine/33.jpg","machine/34.jpg","machine/35.jpg",
                         "machine/36.jpg"
                        }
                    }
                };
                #endregion staticFile
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageEn;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = group;
            return res;
        }

        public Response<DtoGalleryViewModal> AddEditGalleryImage(DtoGalleryViewModal dto)
        {
            Response<DtoGalleryViewModal> res = new Response<DtoGalleryViewModal>();

            var result = false;

            if (dto != null)
            {
                if (dto.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dto.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        isExist.CategoryChildGallaryId = dto.CategoryId;
                        isExist.Description = dto.Description;
                        isExist.TypeGallery = dto.TypeGallery;

                        if (dto.fileUpload != null)
                        {
                            isExist.ImageGallery = dto.filePath;
                        }

                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();
                        dto.filePath = isExist.ImageGallery;
                        dto.CategoryName = Context.TblCategoryChildGallery.AsNoTracking().Where(x => x.Id == dto.CategoryId).FirstOrDefault().CategoryChildName;
                    }
                }
                else
                {
                    var objGallery = new TblGallery()
                    {
                        AddedDate = DateTime.Now,
                        CategoryChildGallaryId = dto.CategoryId,
                        Description = dto.Description,
                        ImageGallery = dto.filePath,
                        TypeGallery = dto.TypeGallery
                    };

                    Add(objGallery);
                    Save();

                    dto.Id = objGallery.Id;
                    dto.CategoryName = Context.TblCategoryChildGallery.AsNoTracking().Where(x => x.Id == dto.CategoryId).FirstOrDefault().CategoryChildName;
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageEn;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = dto;
            return res;
        }

        public Response<bool> DeleteGallery(string ids)
        {
            var listId = ids.Split(',').ToList();

            bool dd = false;

            foreach (var item in listId)
            {
                var result = FindBy(x => x.Id == Convert.ToInt32(item)).FirstOrDefault();

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

        public Response<List<DtoGalleryForViewModal>> GetAllGallery(int type)
        {
            Response<List<DtoGalleryForViewModal>> res = new Response<List<DtoGalleryForViewModal>>();

            var result = (from q in Context.TblGallery.AsNoTracking().Where(x => x.IsDeleted == null && x.TypeGallery == type)
                          select new DtoGalleryForViewModal
                          {
                              Id = q.Id,
                              CategoryId = q.CategoryChildGallaryId,
                              CategoryName = q.TblCategoryChildGallery.CategoryChildName,
                              Description = q.Description,
                              FilePath = q.ImageGallery
                          }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageEn;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }
    }
}
