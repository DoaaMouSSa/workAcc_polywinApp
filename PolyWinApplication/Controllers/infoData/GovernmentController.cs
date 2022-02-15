using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PolyWinApplication.Controllers.infoData
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GovernmentController : ControllerBase
    {

        [HttpGet]
        [Route("GetAllGovernment")]
        public async Task<IActionResult> GetAllGovernment()
        {
            var result = new List<string>() {
            "الإسكندرية", "الإسماعيلية", "أسوان", "أسيوط", "الأقصر","البحر الأحمر","البحيرة",
            "بني سويف","بورسعيد","جنوب سيناء","الجيزة","الدقهلية","دمياط","سوهاج","السويس",
            "الشرقية", "شمال سيناء","الغربية","الفيوم","القاهرة","القليوبية","قنا",
            "كفر الشيخ","مطروح","المنوفية","المنيا","الوادي الجديد",
            };
            return Ok(result);
        }
    }
}
