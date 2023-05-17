using Insurance.Api.Models.Requests;
using Insurance.Domain.Dtos;
using Insurance.Domain.Exceptions;
using Insurance.Domain.Interfaces.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Insurance.Api.Controllers
{
    public class InsuranceController : Controller
    {
        public readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService ?? throw new ArgumentNullException(nameof(insuranceService));
        }

        [HttpPost("product")]
        [ProducesResponseType(typeof(InsuranceDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CalculateProductInsurance([FromBody] ProductInsuranceRequest request)
        {
            var result = await _insuranceService.CalculateProductInsurance(request.ProductId);

            return Ok(result);
        }

        [HttpPost("order")]
        [ProducesResponseType(typeof(InsuranceDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CalculateOrderInsurance([FromBody] OrderInsuranceRequest request)
        {
            var result = await _insuranceService.CalculateOrderInsurance(request.Adapt<OrderDto>());

            return Ok(result);
        }
    }
}