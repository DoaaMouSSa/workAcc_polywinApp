using IPloyWinRepository.InterFace;
using Microsoft.AspNetCore.Mvc;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolyWinApplication.Controllers.infoData
{
  
        [Route("api/notification")]
        [ApiController]
        public class NotificationController : ControllerBase
        {
            private readonly INotificationService _notificationService;
            public NotificationController(INotificationService notificationService)
            {
                _notificationService = notificationService;
            }

            [Route("send")]
            [HttpPost]
            public async Task<IActionResult> SendNotification(NotificationModel notificationModel)
            {
                var result = await _notificationService.SendNotification(notificationModel);
                return Ok(result);
            }
        }
    }

