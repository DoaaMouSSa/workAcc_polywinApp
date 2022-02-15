using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserControlService _userControlService;
        public MessageController(IMessageRepository messageRepository, IUserControlService userControlService)
        {
            _messageRepository = messageRepository;
            _userControlService = userControlService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("AddNewMessage")]
        public Response<bool> AddNewMessage(DtoMessage dtomessage)
        {
            var message = _messageRepository.AddNewMessage(dtomessage);
            return message;
        }
        [HttpGet]
        [Route("GetAllMessages")]
        public Response<List<DtoMessage>> GetAllMessages()
        {
            var messages = _messageRepository.GetAllMessages();
            return messages;
        }
    }
}
