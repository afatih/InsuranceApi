using Insurance.Api.Controllers;
using Insurance.Api.Models.Requests;
using Insurance.Domain.Dtos;
using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Insurance.Tests.UnitTests.Controllers
{
    public class SurchargeControllerTests
    {
        private Mock<ISurchargeService> _surchargeServiceMock;
        private SurchargeController _surchargeController;

        public SurchargeControllerTests()
        {
            _surchargeServiceMock = new Mock<ISurchargeService>();
            _surchargeController = new SurchargeController(_surchargeServiceMock.Object);
        }

        [Fact]
        public void SurchageController_WhenSurchageServiceIsNull_ShouldThrowArgumentNullException()
        {
            ISurchargeService surchargeService = null;

            var exception = Assert.Throws<ArgumentNullException>(() => new SurchargeController(surchargeService));

            Assert.Equal(nameof(surchargeService), exception.ParamName);
            Assert.Equal($"Value cannot be null. (Parameter '{nameof(surchargeService)}')", exception.Message);
        }

        [Fact]
        public void SurchageController_WhenGetAllCalls_ReturnsOk()
        {
            var surcharges = new List<SurchargeDto> {
                new SurchargeDto(1,10),
                new SurchargeDto(2,20),
                new SurchargeDto(3,30)
            };

            _surchargeServiceMock.Setup(x => x.GetAll()).Returns(surcharges);

            var result = _surchargeController.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            var model = Assert.IsAssignableFrom<IEnumerable<SurchargeDto>>(okResult.Value);
            Assert.NotNull(model);
            Assert.Equal(surcharges.Count, model.Count());
        }

        [Fact]
        public void SurchageController_WhenGetByProductTypeIdCalls_ReturnsOk()
        {
            var surcharge = new SurchargeDto(1, 10);
            _surchargeServiceMock.Setup(x => x.GetById(1)).Returns(surcharge);

            var result = _surchargeController.GetByProductTypeId(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            var model = okResult.Value as SurchargeDto;
            Assert.NotNull(model);
            Assert.Equal(10, model.Rate);
        }

        [Fact]
        public void SurchageController_WhenAddCalls_ReturnsOk()
        {
            var surcharge = new SurchargeDto(1, 10);
            var request = new SurchargeRequest { ProductTypeId = 1, Rate = 10 };
            _surchargeServiceMock.Setup(x => x.Add(surcharge));

            var result = _surchargeController.Add(request);

            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void SurchageController_WhenUpdateCalls_ReturnsOk()
        {
            var surcharge = new SurchargeDto(1, 10);
            var request = new SurchargeRequest { ProductTypeId = 1, Rate = 10 };
            _surchargeServiceMock.Setup(x => x.Update(surcharge));

            var result = _surchargeController.Update(request);

            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void SurchageController_WhenDeleteCalls_ReturnsOk()
        {
            _surchargeServiceMock.Setup(x => x.Delete(1));

            var result = _surchargeController.Delete(1);

            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}