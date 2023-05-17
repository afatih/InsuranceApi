using Insurance.Api.Controllers;
using Insurance.Api.Models.Requests;
using Insurance.Domain.Dtos;
using Insurance.Domain.Interfaces.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Insurance.Tests.UnitTests.Controllers
{
    public class InsuranceControllerTests
    {
        public  Mock<IInsuranceService> _insuranceServiceMock;
        public InsuranceController _insuranceController;

        public InsuranceControllerTests()
        {
            _insuranceServiceMock = new Mock<IInsuranceService>();
            _insuranceController = new InsuranceController(_insuranceServiceMock.Object);
        }

        [Fact]
        public void InsuranceController_WhenInsuranceServiceIsNull_ShouldThrowArgumentNullException()
        {
            IInsuranceService insuranceService = null;

            var exception = Assert.Throws<ArgumentNullException>(() => new InsuranceController(insuranceService));

            Assert.Equal(nameof(insuranceService), exception.ParamName);
            Assert.Equal($"Value cannot be null. (Parameter '{nameof(insuranceService)}')", exception.Message);
        }

        [Fact]
        public async Task InsuranceController_WhenRequestValidForProduct_ReturnOkResultWithExpectedInsurance()
        {
            var request = new ProductInsuranceRequest { ProductId = 123 };

            _insuranceServiceMock
                .Setup(x => x.CalculateProductInsurance(request.ProductId))
                .ReturnsAsync(new InsuranceDto(1000));

            var result = await _insuranceController.CalculateProductInsurance(request);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);

            var productInsuranceResult = okResult.Value as InsuranceDto;
            Assert.NotNull(productInsuranceResult);
            Assert.Equal(1000, productInsuranceResult.InsuranceValue);
        }
    }
}