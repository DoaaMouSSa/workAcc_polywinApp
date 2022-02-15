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
    public class ProcessController : ControllerBase
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

        public ProcessController(IInstallmentRepository installmentRepository,
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
        #region Process









        private string ProcessUploadedFileVideoOfClientComm(IFormFile Video)
        {
            try
            {
                if (Video != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\ClientCommVid"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\ClientCommVid");
                    }

                    var Vidpath = _webHostEnvironment.WebRootPath + "\\ClientCommVid\\" + Video.FileName;

                    using (FileStream fileStream = System.IO.File.Create(Vidpath))
                    {
                        Video.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (Vidpath.Length - Vidpath.IndexOf("ClientCommVid"));

                        string Vidnewpath = Vidpath.Substring(Vidpath.IndexOf("ClientCommVid"), length);

                        Vidnewpath = Vidnewpath.Replace('\\', '/');

                        return Vidnewpath;
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }




        private string ProcessUploadedAgentPhoto(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Agent"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Agent");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\Agent\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("Agent"));

                        string newpath = path.Substring(path.IndexOf("Agent"), length);

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


     

        #endregion Process

    }
}
