using IPloyWinRepository.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using PloyWinRepository.EnumData;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinRepository.Repository
{
    public class UserControlService : GenericRepository<ApplicationContext, ApplicationUser>, IUserControlService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserControlService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public List<User> GetUsers(string searchTerm = "")
        {
            var result = FindBy(c => c.UserName.Contains(searchTerm) || c.Email.Contains(searchTerm)).Select(x => new User
            {
                Id = new Guid(x.Id),
                UserName = x.UserName,
                Email = x.Email,
                UserType = x.UserType
            }).ToList();
            return result;
        }

        public ApplicationUser GetUserByName(string userName)
        {
            var result = FindBy(c => c.UserName == userName && c.IsActive == true && c.isDeleted == null).FirstOrDefault();
            return result;
        }
        public string GetAgentNameFromToken(string ManagerId)
        {
            string name = FindBy(x => x.isDeleted == null && x.Id == ManagerId).Select(x => x.UserName).ToList()[0];
            return name;
        }

        public ApplicationUser CheckValidUser(string userName, string pass)
        {
            var result = FindBy(c => c.UserName == userName && c.PasswordHash == pass && c.IsActive == true && c.isDeleted == null).FirstOrDefault();
            return result;
        }

        public async Task<Response<User>> GetUser(string id)
        {
            Response<User> res = new Response<User>();
            try
            {
                var result = FindBy(c => c.Id == id).Select(x => new User
                {
                    Id = new Guid(x.Id),
                    UserName = x.UserName,
                    Email = x.Email,
                    UserType = x.UserType
                }).FirstOrDefault();

                if (result != null)
                {
                    res.code = StaticApiStatus.ApiSuccess.Code;
                    res.message = StaticApiStatus.ApiSuccess.MessageEn;
                    res.status = StaticApiStatus.ApiSuccess.Status;
                    res.IsSuccess = true;
                    res.payload = result;
                    return res;
                }
                else
                {
                    res.code = StaticApiStatus.ApiEmpty.Code;
                    res.message = StaticApiStatus.ApiEmpty.MessageEn;
                    res.status = StaticApiStatus.ApiEmpty.Status;
                    res.payload = null;
                    res.IsSuccess = false;
                    return res;
                }
            }
            catch (System.Exception ex)
            {
                res.code = StaticApiStatus.ApiFaild.Code;
                res.message = ex.Message;
                res.status = StaticApiStatus.ApiFaild.Status;
                res.payload = null;
                res.IsSuccess = false;
                return res;
            }
        }

        public async Task<Response<string>> InsertUser(DtoUserAndAgent user, ApplicationUser ManagerId)
        {
            var res = new Response<string>();
            try
            {
                var resUser = GetUserByName(user.userName);
                if (resUser != null)
                {
                    //  res.code = 
                    res.message = StaticApiStatus.ApiDuplicate.MessageAr;
                    res.status = StaticApiStatus.ApiFaild.Status;
                    res.payload = "False";
                    res.IsSuccess = false;
                    return res;

                }

                user.userId = Guid.NewGuid();

                ApplicationUser appUser = new ApplicationUser()
                {
                    Id = user.userId.ToString(),
                    ManagerId = ManagerId.Id,
                    UserType = user.userType,
                    UserName = user.userName,
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    Email = user.email,
                    PasswordHash = user.password,
                    IsActive = (user.userType == 2 || user.userType == 4) ? true : false
                };

                var result = await _userManager.CreateAsync(appUser);
                if (result.Succeeded)
                {
                    res.code = StaticApiStatus.ApiSuccess.Code;
                    res.message = StaticApiStatus.ApiSuccess.MessageEn;
                    res.status = StaticApiStatus.ApiSuccess.Status;
                    res.payload = user.userId.ToString();
                    res.IsSuccess = true;
                    return res;
                }

                res.code = StaticApiStatus.ApiSuccess.Code; //result.Errors.Select(c => c.Code).FirstOrDefault();
                res.message = StaticApiStatus.ApiSuccess.MessageEn; //string.Join(" , ", result.Errors.Select(c => c.Description));
                res.status = StaticApiStatus.ApiSuccess.Status;
                res.payload = "True";
                res.IsSuccess = true;
                return res;
            }
            catch (System.Exception ex)
            {
                res.code = StaticApiStatus.ApiFaild.Code;
                res.message = ex.Message;
                res.status = StaticApiStatus.ApiFaild.Status;
                res.payload = "False";
                res.IsSuccess = false;
                return res;
            }
        }

        public async Task<Response<string>> InsertClient(DtoClient user, ApplicationUser ManagerId)
        {
            var res = new Response<string>();
            try
            {

                var resUser = GetUserByName(user.userName);
                if (resUser != null)
                {
                  //  res.code = 
                    res.message = StaticApiStatus.ApiDuplicate.MessageAr;
                    res.status = StaticApiStatus.ApiFaild.Status;
                    res.payload = "False";
                    res.IsSuccess = false;
                    return res;

                }
                user.userId = Guid.NewGuid();
                ApplicationUser appUser = new ApplicationUser()
                {
                    Id = user.userId.ToString(),
                    ManagerId = ManagerId.Id,
                    UserType = user.userType,
                    UserName = user.userName,
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    Email = user.email,
                    IsActive = true,//(user.userType == 2 || user.userType == 4) ? true : false
                    PasswordHash = user.password
                };

                var result = await _userManager.CreateAsync(appUser);
                if (result.Succeeded)
                {
                    res.code = StaticApiStatus.ApiSuccess.Code;
                    res.message = StaticApiStatus.ApiSuccess.MessageEn;
                    res.status = StaticApiStatus.ApiSuccess.Status;
                    res.payload = user.userId.ToString();
                    res.IsSuccess = true;
                    return res;
                }

                res.code = result.Errors.Select(c => c.Code).FirstOrDefault();
                res.message = string.Join(" , ", result.Errors.Select(c => c.Description));
                res.status = StaticApiStatus.ApiFaild.Status;
                res.payload = "False";
                res.IsSuccess = false;
                return res;
            }
            catch (System.Exception ex)
            {
                res.code = StaticApiStatus.ApiFaild.Code;
                res.message = ex.Message;
                res.status = StaticApiStatus.ApiFaild.Status;
                res.payload = "False";
                res.IsSuccess = false;
                return res;
            }
        }

        public async Task<Response<bool>> UpdateUser(User user)
        {
            var res = new Response<bool>();
            try
            {
                var appUser = 
                    await _userManager.FindByIdAsync(user.Id.ToString());

                appUser.UserName = user.UserName;
                appUser.Email = user.Email;
                appUser.PhoneNumber = user.PhoneNumber;
                var result = await _userManager.UpdateAsync(appUser);
                if (result.Succeeded)
                {
                    res.code = StaticApiStatus.ApiSuccess.Code;
                    res.message = StaticApiStatus.ApiSuccess.MessageEn;
                    res.status = StaticApiStatus.ApiSuccess.Status;
                    res.payload = true;
                    res.IsSuccess = true;
                    return res;
                }
                res.code = result.Errors.Select(c => c.Code).FirstOrDefault();
                res.message = string.Join(" , ", result.Errors.Select(c => c.Description));
                res.status = StaticApiStatus.ApiFaild.Status;
                res.payload = false;
                res.IsSuccess = false;
                return res;
            }
            catch (System.Exception ex)
            {
                res.code = StaticApiStatus.ApiFaild.Code;
                res.message = ex.Message;
                res.status = StaticApiStatus.ApiFaild.Status;
                res.payload = false;
                res.IsSuccess = false;
                return res;
            }
        }

        public async Task<Response<bool>> DeleteUser(string id)
        {
            var res = new Response<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    res.code = StaticApiStatus.ApiSuccess.Code;
                    res.message = StaticApiStatus.ApiSuccess.MessageEn;
                    res.status = StaticApiStatus.ApiSuccess.Status;
                    res.payload = true;
                    res.IsSuccess = true;
                    return res;
                }
                res.code = result.Errors.Select(c => c.Code).FirstOrDefault();
                res.message = string.Join(" , ", result.Errors.Select(c => c.Description));
                res.status = StaticApiStatus.ApiFaild.Status;
                res.payload = false;
                res.IsSuccess = false;
                return res;
            }
            catch (System.Exception ex)
            {
                res.code = StaticApiStatus.ApiFaild.Code;
                res.message = ex.Message;
                res.status = StaticApiStatus.ApiFaild.Status;
                res.payload = false;
                res.IsSuccess = false;
                return res;
            }
        }

        public async Task<Response<bool>> AddUserRoles(string userId, List<string> roles)
        {
            var res = new Response<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var old = await _userManager.RemoveFromRolesAsync(user, roles);
                var oldROles = await _userManager.GetRolesAsync(user);
                var remove = await _userManager.RemoveFromRolesAsync(user, oldROles);
                var result = await _userManager.AddToRolesAsync(user, roles);
                if (result.Succeeded)
                {
                    res.code = StaticApiStatus.ApiSuccess.Code;
                    res.message = StaticApiStatus.ApiSuccess.MessageEn;
                    res.status = StaticApiStatus.ApiSuccess.Status;
                    res.payload = true;
                    res.IsSuccess = true;
                    return res;
                }
                res.code = result.Errors.Select(c => c.Code).FirstOrDefault();
                res.message = string.Join(" , ", result.Errors.Select(c => c.Description));
                res.status = StaticApiStatus.ApiFaild.Status;
                res.payload = false;
                res.IsSuccess = false;
                return res;
            }
            catch (System.Exception ex)
            {
                res.code = StaticApiStatus.ApiFaild.Code;
                res.message = ex.Message;
                res.status = StaticApiStatus.ApiFaild.Status;
                res.payload = false;
                res.IsSuccess = false;
                return res;
            }
        }

        public async Task<Response<List<UserWithManager>>> GetUserNotActive()
        {
            Response<List<UserWithManager>> res = new Response<List<UserWithManager>>();
            var result = FindBy(c => c.IsActive == false && c.isDeleted == null && c.UserType == 3).Select(x => new UserWithManager
            {
                Id = new Guid(x.Id),
                UserName = x.UserName,
                UserType = x.UserType,
                UserTypeName = x.UserType == 1 ? "PolyWin" : (x.UserType == 2 ? "وكيل" : (x.UserType == 3 ? "ورشة" : "عميل")),
                Password = x.PasswordHash,
                ManagerId = x.ManagerId,
            }).AsEnumerable().Select(x => new UserWithManager
            {
                Id = x.Id,
                UserName = x.UserName,
                UserType = x.UserType,
                UserTypeName = x.UserType == 1 ? "PolyWin" : (x.UserType == 2 ? "وكيل" : (x.UserType == 3 ? "ورشة" : "عميل")),
                Password = x.Password,
                ManagerId = x.ManagerId,
                managerName = GetAgentNameFromToken(x.ManagerId)
            }).ToList();
            if (result != null)
            {
                res.code = StaticApiStatus.ApiSuccess.Code;
                res.message = StaticApiStatus.ApiSuccess.MessageAr;
                res.status = StaticApiStatus.ApiSuccess.Status;
                res.IsSuccess = true;
                res.payload = result;
                return res;
            }

            res.code = StaticApiStatus.ApiEmpty.Code;
            res.message = StaticApiStatus.ApiEmpty.MessageEn;
            res.status = StaticApiStatus.ApiEmpty.Status;
            res.payload = null;
            res.IsSuccess = false;
            return res;
        }

        public async Task<Response<string>> ActiveAccounts(string ids)
        {
            Response<string> res = new Response<string>();

            var listId = ids.Split(',').ToList();

            foreach (var id in listId)
            {
                var result = FindBy(x => x.Id == id.ToString()).FirstOrDefault();
                if (result != null)
                {
                    result.IsActive = true;

                    Edit(result);
                }
            }
            Save();


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = "تم الحفظ بنجاح";

            return res;
        }

        public async Task<Response<string>> ActiveNotActiveAccounts(string ids)
        {
            Response<string> res = new Response<string>();

            var listId = ids.Split(',').ToList();

            foreach (var id in listId)
            {
                var result = FindBy(x => x.Id == id.ToString()).FirstOrDefault();
                if (result != null)
                {
                    result.IsActive = !result.IsActive;

                    Edit(result);
                }
            }
            Save();


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = "تم الحفظ بنجاح";

            return res;
        }

        public async Task<Response<string>> ResetPassword(string ids, string Token)
        {
            Response<string> res = new Response<string>();

            var listId = ids.Split(',').ToList();

            foreach (var id in listId)
            {
                var result = FindBy(x => x.Id == id.ToString()).FirstOrDefault();
                if (result != null)
                {
                    result.PasswordHash = "0123456789";

                    Edit(result);
                }
            }

            Save();



            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = "تم الحفظ بنجاح";

            return res;
        }

        public async Task<Response<int>> GetAllUserTypeAgentCount()
        {
            Response<int> res = new Response<int>();

            var countAgent = FindBy(x => x.isDeleted == null && x.UserType == 2 && x.IsActive == true).Count();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = countAgent;

            return res;
        }

        public async Task<Response<int>> GetAllUserTypeWorkShopCount()
        {
            Response<int> res = new Response<int>();

            var countWorkShop = FindBy(x => x.isDeleted == null && x.UserType == 3 && x.IsActive == true).Count();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = countWorkShop;

            return res;
        }

        public List<string> GetUserIdReleatedManagerId(string ManagerId)
        {
            var result = FindBy(x => x.isDeleted == null && x.ManagerId == ManagerId).Select(x => x.Id).ToList();

            return result;
        }



        public List<string> getListWorkShop()
        {
            var result = FindBy(x => x.UserType == 3).Select(x => x.Id).ToList();

            return result;
        }

        public async Task<bool> ChangePassword(string userName, ChanagePasswordViewModel model)
        {

            var user = GetUserByName(userName);
            var appUser = await _userManager.FindByIdAsync(user.Id.ToString());

            appUser.PasswordHash = model.NewPassword;

            var result = await _userManager.UpdateAsync(appUser);

            // var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (result.Succeeded)
            {

                return true;
            }

            return false;
        }
    }

}
