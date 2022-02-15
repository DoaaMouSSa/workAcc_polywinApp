using IPloyWinRepository.InterFace;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PolyWinApplication.Controllers.infoData
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryCostController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IParentCategoryRepository _parentCategoryRepository;
        private readonly ISubCategoryRepository _SubCategoryRepository;

        public CategoryCostController(
            ISubCategoryRepository SubCategoryRepository,
            IParentCategoryRepository parentCategoryRepository,
            IWebHostEnvironment webHostEnvironment

            )
        {
            _SubCategoryRepository = SubCategoryRepository;
            _parentCategoryRepository = parentCategoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        #region parentCategoryCost

        [HttpGet]
        [Route("GetAllParentCategory")]
        public IActionResult GetAllParentCategory()
        {
            var result = _parentCategoryRepository.GetAllParentCategory();

            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllParentCategoryForDropDown")]
        public IActionResult GetAllParentCategoryForDropDown()
        {
            var result = _parentCategoryRepository.GetAllParentCategoryForDropDown();

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteParentCategory")]
        public IActionResult DeleteParentCategory(string ids)
        {
            var result = _parentCategoryRepository.DeleteParentCategory(ids);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllParentSubCategory")]
        public IActionResult GetAllParentSubCategory()
        {
            var result = _parentCategoryRepository.GetAllParentSubCategory();

            return Ok(result);
        }


        [HttpPost]
        [Route("AddEditParentCategory")]
        public IActionResult AddEditParentCategory(DtoParentCategory dto)
        {
            if (dto.File != null)
            {
                dto.FilePath = ProcessUploadedFileOfParentCategory(dto.File);
            }

            if (dto.Logo != null)
            {
                dto.LogoUrl = ProcessUploadedFileOfParentCategory(dto.Logo);
            }

            var result = _parentCategoryRepository.AddEditParentCategory(dto);

            return Ok(result);
        }

        #endregion parentCategoryCost

        #region SubCategoryCost

        [HttpGet]
        [Route("GetAllSubCategory")]
        public IActionResult GetAllSubCategory()
        {
            var result = _SubCategoryRepository.GetAllSubCategory();

            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllSubCategoryForDropDown")]
        public IActionResult GetAllSubCategoryForDropDown()
        {
            var result = _SubCategoryRepository.GetAllSubCategoryForDropDown();

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteSubCategory")]
        public IActionResult DeleteSubCategory(string ids)
        {
            var result = _SubCategoryRepository.DeleteSubCategory(ids);

            return Ok(result);
        }


        [HttpPost]
        [Route("AddEditSubCategory")]
        public IActionResult AddEditSubCategory([FromForm] DtoSubCategory dto)
        {
            if (dto.fileUpload != null)
            {
                dto.FilePath = ProcessUploadedFileOfSubCategory(dto.fileUpload);
            }

            if (dto.Logo != null)
            {
                dto.LogoUrl = ProcessUploadedFileOfSubCategory(dto.Logo);
            }

            var result = _SubCategoryRepository.AddEditSubCategory(dto);

            return Ok(result);
        }

        #endregion SubCategoryCost
        private string ProcessUploadedFileOfParentCategory(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\ParentCategory"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\ParentCategory");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\ParentCategory\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("ParentCategory"));

                        string newpath = path.Substring(path.IndexOf("ParentCategory"), length);

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
        private string ProcessUploadedFileOfSubCategory(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\SubCategory"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\SubCategory");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\SubCategory\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("SubCategory"));

                        string newpath = path.Substring(path.IndexOf("SubCategory"), length);

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
    }
}
