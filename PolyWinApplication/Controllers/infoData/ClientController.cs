using IPloyWinRepository.InterFace;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace PolyWinApplication.Controllers.infoData
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientController : ControllerBase
    {
        private readonly IUserControlService _userControlService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDescountRepository _descountRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDetailsRepository _invoiceDetailsRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IClientTypeRepository _clientTypeRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IContractClientRepository _contractClientRepository;
        private readonly IPayedContractClientRepository _payedContractClientRepository;
        private readonly IGallaryUserRepository _gallaryUserRepository;
        private readonly ICategoryGalleryRepository _categoryGalleryRepository;
        private readonly IGalleryRepository _galleryRepository;
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly IDataSheetsRepository _dataSheetsRepository;
        private readonly ICatalogueRepository _catalogueRepository;
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly IParentCategoryRepository _parentCategoryRepository;
        private readonly ISubCategoryRepository _SubCategoryRepository;
        private readonly IColorsRepository _ColorsRepository;
        private readonly ICategoryChildGalleryRepository _categoryChildGalleryRepository;
        private readonly IProductNameRepository _productNameRepository;
        private readonly IParentProductCategoryRepository _parentProductCategoryRepository;
        private readonly IProductIngredientsRepository _productIngredientsRepository;
        private readonly IproductIngredientAccessoryRepository _productIngredientAccessoryRepository;
        private readonly ICostCalculationRepository _costCalculationRepository;
        private readonly IWarrantyContractsRepository _warrantyContractsRepository;
        private readonly IInstallmentRepository _installmentRepository;
        private readonly IFactorRepository _factorRepository;
        private readonly IPriceListRepository _priceListRepository;
        private readonly IClientOpinionRepository _clientOpinionRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IStoreDataRepository _storeDataRepository;
        private readonly IItemTypeRepository _itemTypeRepository;
        private readonly IBanqueRepository _banqueRepository;
        private readonly IPurchaseRepository _purchaseRepository;

        public ClientController(IInstallmentRepository installmentRepository,
            IWarrantyContractsRepository warrantyContractsRepository,
            ICostCalculationRepository costCalculationRepository,
            IproductIngredientAccessoryRepository productIngredientAccessoryRepository,
            IProductIngredientsRepository productIngredientsRepository,
            IParentProductCategoryRepository parentProductCategoryRepository,
            IProductNameRepository productNameRepository,
            ICategoryChildGalleryRepository categoryChildGalleryRepository,
            IColorsRepository ColorsRepository,
            ISubCategoryRepository SubCategoryRepository,
            IParentCategoryRepository parentCategoryRepository,
            ICompanyInfoRepository companyInfoRepository,
            ICatalogueRepository catalogueRepository,
            IDataSheetsRepository dataSheetsRepository,
            ICategoryTypeRepository categoryTypeRepository,
            IGalleryRepository galleryRepository,
            ICategoryGalleryRepository categoryGalleryRepository,
            IGallaryUserRepository gallaryUserRepository,
            IPayedContractClientRepository payedContractClientRepository,
            IContractClientRepository contractClientRepository,
            IClientRepository clientRepository, IClientTypeRepository clientTypeRepository,
            IStoreRepository storeRepository, IAgentRepository agentRepository,
            IWebHostEnvironment webHostEnvironment,
            IUserControlService userControlService, IDescountRepository descountRepository,
            IProductsRepository productsRepository,
            ICategoryRepository categoryRepository,
            IInvoiceRepository invoiceRepository, IInvoiceDetailsRepository invoiceDetailsRepository,
            IFactorRepository factorRepository,
            IPriceListRepository priceListRepository,
            IClientOpinionRepository clientOpinionRepository,
            ISupplierRepository supplierRepository,
            IStoreDataRepository storeDataRepository,
           IItemTypeRepository itemTypeRepository,
             IBanqueRepository banqueRepository,
             IPurchaseRepository purchaseRepository

            )
        {
            _installmentRepository = installmentRepository;
            _warrantyContractsRepository = warrantyContractsRepository;
            _costCalculationRepository = costCalculationRepository;
            _productIngredientAccessoryRepository = productIngredientAccessoryRepository;
            _productIngredientsRepository = productIngredientsRepository;
            _parentProductCategoryRepository = parentProductCategoryRepository;
            _productNameRepository = productNameRepository;
            _categoryChildGalleryRepository = categoryChildGalleryRepository;
            _ColorsRepository = ColorsRepository;
            _SubCategoryRepository = SubCategoryRepository;
            _parentCategoryRepository = parentCategoryRepository;
            _companyInfoRepository = companyInfoRepository;
            _catalogueRepository = catalogueRepository;
            _dataSheetsRepository = dataSheetsRepository;
            _categoryTypeRepository = categoryTypeRepository;
            _categoryGalleryRepository = categoryGalleryRepository;
            _gallaryUserRepository = gallaryUserRepository;
            _payedContractClientRepository = payedContractClientRepository;
            _clientRepository = clientRepository;
            _clientTypeRepository = clientTypeRepository;
            _storeRepository = storeRepository;
            _webHostEnvironment = webHostEnvironment;
            _invoiceRepository = invoiceRepository;
            _userControlService = userControlService;
            _categoryRepository = categoryRepository;
            _descountRepository = descountRepository;
            _productsRepository = productsRepository;
            _invoiceDetailsRepository = invoiceDetailsRepository;
            _agentRepository = agentRepository;
            _contractClientRepository = contractClientRepository;
            _galleryRepository = galleryRepository;
            _factorRepository = factorRepository;
            _priceListRepository = priceListRepository;
            _clientOpinionRepository = clientOpinionRepository;
            _supplierRepository = supplierRepository;
            _storeDataRepository = storeDataRepository;
            _itemTypeRepository = itemTypeRepository;
            _banqueRepository = banqueRepository;
            _purchaseRepository = purchaseRepository;
        }


        



        #region client

        [HttpPost]
        [Route("CreateNewClient")]
        public async Task<IActionResult> CreateNewClient([FromForm] DtoClient user)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var managerId = _userControlService.GetUserByName(userClaim.Name);
            var _user = await _userControlService.InsertClient(user, managerId);
            if (_user.payload != "False")
            {
                user.ClientLogoURL = ProcessUploadedFileOfClient(user.Photo);
                user.userId = new Guid(_user.payload);
                var result = _clientRepository.AddNewCLient(user);
            }
            return Ok(_user);
        }

        [HttpGet]
        [Route("GetAllClientByUserLogIn")]
        public async Task<IActionResult> GetAllClientByUserLogIn()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var UserId = _userControlService.GetUserByName(userClaim.Name);

            var result = _clientRepository.GetAllClientByUserLogIn(UserId.Id);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllClientInfoByUserLogIn")]
        public async Task<IActionResult> GetAllClientInfoByUserLogIn()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var UserId = _userControlService.GetUserByName(userClaim.Name);

            var result = _clientRepository.GetAllClientInfoByUserLogIn(UserId.Id);

            return Ok(result);
        }


        [HttpGet]
        [Route("GetClientInfoById")]
        public async Task<IActionResult> GetClientInfoById()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var UserId = _userControlService.GetUserByName(userClaim.Name);

            var result = _clientRepository.GetClientInfoById(UserId.Id);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetClientTypeCount")]
        public async Task<IActionResult> GetClientTypeCount()
        {
            var result = _clientRepository.GetClientTypeCount();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetClientTypeDetails")]
        public async Task<IActionResult> GetClientTypeDetails()
        {
            var result = _clientRepository.GetClientTypeDetails();

            return Ok(result);
        }

        #endregion
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
        private string ProcessUploadedFileOfClientComm(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\ClientComm"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\ClientComm");
                    }

                    var Imgpath = _webHostEnvironment.WebRootPath + "\\ClientComm\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(Imgpath))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (Imgpath.Length - Imgpath.IndexOf("ClientComm"));

                        string Imgnewpath = Imgpath.Substring(Imgpath.IndexOf("ClientComm"), length);

                        Imgnewpath = Imgnewpath.Replace('\\', '/');

                        return Imgnewpath;
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
