using Insurance.Api.Models.Requests;
using Insurance.Domain.Dtos;
using Insurance.Domain.Exceptions;
using Insurance.Domain.Interfaces.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace Insurance.Api.Controllers
{
    [Route("[controller]")]
    public class SurchargeController : Controller
    {
        public readonly ISurchargeService _surchargeService;

        public SurchargeController(ISurchargeService surchargeService)
        {
            _surchargeService = surchargeService ?? throw new ArgumentNullException(nameof(surchargeService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<SurchargeDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            return Ok(_surchargeService.GetAll());
        }

        [HttpGet("{productTypeId}")]
        [ProducesResponseType(typeof(SurchargeDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetByProductTypeId(int productTypeId)
        {
            return Ok(_surchargeService.GetById(productTypeId));
        }

        [HttpPost]
        public IActionResult Add([FromBody] SurchargeRequest surchargeCreatRequest)
        {
            _surchargeService.Add(surchargeCreatRequest.Adapt<SurchargeDto>());
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] SurchargeRequest surchargeCreatRequest)
        {
            _surchargeService.Update(surchargeCreatRequest.Adapt<SurchargeDto>());
            return Ok();
        }

        [HttpDelete("{productTypeId}")]
        public IActionResult Delete(int productTypeId)
        {
            _surchargeService.Delete(productTypeId);
            return Ok();
        }
    }
}