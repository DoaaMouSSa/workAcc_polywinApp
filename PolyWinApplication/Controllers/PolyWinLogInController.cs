using IPloyWinRepository.InterFace;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static PloyWinRepository.EnumData.StaticApiStatus;

namespace PolyWinApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolyWinLogInController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<PolyWinLogInController> _logger;
        private readonly IUserControlService _userControlService;
        private readonly IAgentRepository _agentRepository;
        private readonly IGalleryRepository _galleryRepository;
        private readonly IDescountRepository _descountRepository;
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly IDataSheetsRepository _dataSheetsRepository;
        private readonly ICatalogueRepository _catalogueRepository;
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly ICategoryGalleryRepository _categoryGalleryRepository;
        private readonly IParentCategoryRepository _parentCategoryRepository;
        //for Materials
        private readonly ICategoryRepository _categoryRepository;
        private readonly IParentProductCategoryRepository _parentProductCategoryRepository;
        private readonly IProductsRepository _productRepository;
        private readonly IguaranteeRepository _guaranteeRepository;
        private readonly IFactorRepository _factorRepository;
        private readonly IPriceListRepository _priceListRepository;
        private readonly IClientOpinionRepository _clientOpinionRepository;
        //
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IClientRepository _clientRepository;

        public PolyWinLogInController(ICategoryGalleryRepository categoryGalleryRepository, ICompanyInfoRepository companyInfoRepository, ICatalogueRepository catalogueRepository, IDataSheetsRepository dataSheetsRepository, IDescountRepository descountRepository, IGalleryRepository galleryRepository, IUserControlService userControlService, ILogger<PolyWinLogInController> logger, UserManager<ApplicationUser> userManager, IConfiguration configuration, IParentCategoryRepository parentCategoryRepository,
            IAgentRepository agentRepository, ICategoryTypeRepository categoryTypeRepository, IProductsRepository productsRepository, IguaranteeRepository guaranteeRepository, IClientOpinionRepository clientOpinionRepository, IFactorRepository factorRepository,
     IPriceListRepository priceListRepository, IParentProductCategoryRepository parentProductCategoryRepository, ICategoryRepository categoryRepository,
       IInvoiceRepository invoiceRepository,
        IWebHostEnvironment webHostEnvironment,
        IClientRepository clientRepository
        )
        {
            _clientRepository = clientRepository;
            _webHostEnvironment = webHostEnvironment;
            _invoiceRepository = invoiceRepository;
            _categoryGalleryRepository = categoryGalleryRepository;
            _companyInfoRepository = companyInfoRepository;
            _catalogueRepository = catalogueRepository;
            _dataSheetsRepository = dataSheetsRepository;
            _categoryTypeRepository = categoryTypeRepository;
            _logger = logger;
            //_clientRepository = clientRepository;
            _userManager = userManager;
            _configuration = configuration;
            _userControlService = userControlService;
            _agentRepository = agentRepository;
            _galleryRepository = galleryRepository;
            _descountRepository = descountRepository;
            _parentCategoryRepository = parentCategoryRepository;
            _parentProductCategoryRepository = parentProductCategoryRepository;
            _productRepository = productsRepository;
            _guaranteeRepository = guaranteeRepository;
            _categoryRepository = categoryRepository;
            _factorRepository = factorRepository;
            _priceListRepository = priceListRepository;
            _clientOpinionRepository = clientOpinionRepository;
        }





     

        #region  Gallery

        [HttpGet]
        [Route("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var result = _categoryTypeRepository.GetAllCategoryGallery();
            return Ok(result);
        }

        #endregion



        #region CategoryGallery

        [HttpGet]
        [Route("GetAllCategoryGallery")]
        public async Task<IActionResult> GetAllCategoryGallery()
        {
            var result = _categoryGalleryRepository.GetCategoryWithFile();

            return Ok(result);
        }

        #endregion
        #region ParentCategory
        //for product
        [HttpGet]
        [Route("GetAllParentCategory")]
        public async Task<IActionResult> GetAllParentCategory()
        {
            var result = _parentCategoryRepository.GetAllParentCategory();

            return Ok(result);
        }

        #endregion
        #region CategoryForMaterials
        //for materials or datasheet    
        //[HttpGet]
        //[Route("GetAllProductPerCategory")]
        //public async Task<IActionResult> GetAllProductPerCategory()
        //{
        //    var Product = _productRepository.GetAllProductPerCategory();
        //    return Ok(Product);
        //}
        #endregion

        #region workshopbyGov
        [HttpGet]
        [Route("GetAllWorkShopsByGov")]
        public async Task<IActionResult> GetWorkShopByGov()
        {
            var workshops = _agentRepository.GetWorkShopByGov();
            return Ok(workshops);
        }
        #endregion


        #region GetAgentById
        [HttpGet]
        [Route("GetAgentById")]
        public async Task<IActionResult> getagentbyid(int id)
        {
            var agent = _agentRepository.GetAgentById(id);
            return Ok(agent);
        }

        [HttpGet]
        [Route("GetAllUserTypeAgentDetails")]
        public async Task<IActionResult> GetAllUserTypeAgentDetails()
        {
            var agent = _agentRepository.GetAllUserTypeAgentDetails();
            return Ok(agent);
        }

        [HttpGet]
        [Route("GetAllUserTypeWorkShopDetails")]
        public async Task<IActionResult> GetAllUserTypeWorkShopDetails()
        {
            var agent = _agentRepository.GetAllUserTypeWorkShopDetails();
            return Ok(agent);
        }

        #endregion

        #region GetSubCategoryAndGalleryById
        [HttpGet]
        [Route("GetAllGalleriesbyCat")]
        public async Task<IActionResult> GetAllCategoryGalleryById(int id)
        {
            var SubCat = _categoryTypeRepository.GetAllCategoryGalleryById(id);
            return Ok(SubCat);
        }
        #endregion

        #region getProductsWithColors
        [HttpGet]
        [Route("GetProductsColors")]
        public async Task<IActionResult> GetProductsWithColors()
        {
            var proColors = _productRepository.GetAllProductWithColorForShow();
            return Ok(proColors);
        }
        #endregion

        //GetAllProductWithNameAndCode()
        //    #region getproductwithname&cat&code
        //[HttpGet]
        //[Route("GetAllProductWithNameAndCode")]
        //public async Task<IActionResult> GetAllProductWithNameAndCode()
        //{
        //    var proColors = _productRepository.getall();
        //    return Ok(proColors);
        //}
        //#endregion
        #region ParentProductCategory

        [HttpGet]
        [Route("GetAllParentProductCategory")]
        public IActionResult GetAllParentProductCategory()
        {
            var result = _parentProductCategoryRepository.GetAllParentProductCategory();
            return Ok(result);
        }
        #endregion
        #region getguaranteeText 
        [HttpGet]
        [Route("GetguaranteeText")]
        public async Task<IActionResult> GetguaranteeText()
        {
            var txt = _guaranteeRepository.GetguaranteeText();
            return Ok(txt);
        }
        #endregion

        #region getClientComment 
        [HttpGet]
        [Route("GetClientOpinions")]
        public async Task<IActionResult> GetClientOpinions()
        {
            var comment = _clientOpinionRepository.GetAllClientsOpinion();
            return Ok(comment);
        }
        #endregion

        [HttpGet]
        [Route("GetAllFactor")]
        public async Task<IActionResult> GetAllFactor()
        {
            var Factor = _factorRepository.GetAllFactor();
            return Ok(Factor);
        }

        [HttpGet]
        [Route("GetAllPriceLst")]
        public async Task<IActionResult> GetAllPriceLst()
        {
            var Pricefile = _priceListRepository.GetAllPriceLst();
            return Ok(Pricefile);
        }

        [HttpGet]
        [Route("GetParentCategorywithProductForWebApp")]
        public Response<List<DtoGroupCategoryWithProduct>> GetParentCategorywithProductForWebApp()
        {


            var Cateory = _categoryRepository.GetParentCategorywithProductForWebApp();
            return Cateory;
        }
     


        [HttpGet]
        [Route("GetStatisticsForAgent")]
        public async Task<IActionResult> GetStatisticsForAgent(int userType)
        {
            var result = await _invoiceRepository.GetStatisticsForAgent(userType);
            return Ok(result);
        }


        private string ProcessUploadedFileOfClient(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Client"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Client");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\Client\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("Client"));

                        string newpath = path.Substring(path.IndexOf("Client"), length);

                        newpath = newpath.Replace('\\', '/');

                        return newpath;
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #region workshopbyOneGov
        [HttpGet]
        [Route("GetWorkShopByOneGov")]
        public async Task<IActionResult> GetWorkShopByOneGov(string Govname)
        {
            var workshops = _agentRepository.GetWorkShopByOneGov(Govname);
            return Ok(workshops);
        }
        #endregion
    }
}
