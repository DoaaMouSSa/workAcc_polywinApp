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
    public class PaymentContoller
    {
            private readonly IPaymentMethod _paymentRepository;
            public PaymentContoller(IPaymentMethod paymentRepository)
            {
                _paymentRepository = paymentRepository;
            }
            #region Payment
            [HttpPost]
            [Route("AddEditPayment")]
            public Task<Response<DtoPaymentMethod>> AddEditPayment(DtoPaymentMethod dtoPayment)
            {
                var Payment = _paymentRepository.AddEditPaymentMethod(dtoPayment);
                return Payment;
            }

            [HttpGet]
            [Route("getPayment")]
            public Task<Response<List<DtoPaymentMethod>>> getPayment()
            {

                var Payment = _paymentRepository.getPaymentMethod();
                return Payment;
            }

            [HttpGet]
            [Route("DeleteBank")]
            public Task<Response<bool>> DeletePayment(string ids)
            {
                var Bank = _paymentRepository.DeletePaymentMethod(ids);
                return Bank;
            }
            #endregion
        }
    }
