using Insurance.Api.Models.Requests;
using Insurance.Application.Handlers;
using Insurance.Application.Services;
using Insurance.Domain.Dtos;
using Insurance.Domain.Interfaces.Handlers;
using Insurance.Domain.Interfaces.Providers;
using Insurance.Domain.Interfaces.Services;
using Insurance.Tests.DataGenerators.Services;
using Mapster;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Insurance.Tests.UnitTests.Services
{
    public class InsuranceServiceTests
    {
        private Mock<IProductProvider> _productProviderMock;
        private Mock<IProductTypeProvider> _productTypeProviderMock;
        private Mock<ISurchargeService> _surchargeServiceMock;
        private List<IInsuranceCalculateHandler> _calculateHandlers;
        private IInsuranceService _insuranceService;

        public InsuranceServiceTests()
        {
            _productProviderMock = new Mock<IProductProvider>();
            _productTypeProviderMock = new Mock<IProductTypeProvider>();
            _surchargeServiceMock = new Mock<ISurchargeService>();
            var handlers = new List<IInsuranceCalculateHandler>();
            handlers.Add(new SalesPriceHandler());
            handlers.Add(new ProductTypeMatchHandler());
            handlers.Add(new ProductTypeContainsHandler());
            handlers.Add(new SurchargeHandler());
            _calculateHandlers = handlers;
            _insuranceService = new InsuranceService(_productProviderMock.Object, _productTypeProviderMock.Object, _surchargeServiceMock.Object, _calculateHandlers);
        }

        [Fact]
        public void InsuranceService_WhenProductTypesCanBeInsuredFalse_ReturnDefaultInt()
        {
            _productProviderMock.Setup(x => x.GetProductById(1)).ReturnsAsync(new ProductDto(1, "Product1", 100, 1));
            _productTypeProviderMock.Setup(x => x.GetProductTypeById(1)).ReturnsAsync(new ProductTypeDto(1, "ProductType1", false));
            _surchargeServiceMock.Setup(x => x.GetById(1)).Returns(new SurchargeDto(1, 10));

            var result = _insuranceService.CalculateProductInsurance(1);

            var okResult = Assert.IsType<Task<InsuranceDto>>(result);
            Assert.Equal(default(int), result.Result.InsuranceValue);
        }

        [Theory]
        [ClassData(typeof(InsuranceServiceProductDatas))]
        public void InsuranceService_WhenProductTypesCanBeInsuredTrue_ShouldReturnExpectedInsurance(ProductDto product, ProductTypeDto productType, SurchargeDto surcharge, InsuranceDto insurance)
        {
            _productProviderMock.Setup(x => x.GetProductById(product.Id)).ReturnsAsync(product);
            _productTypeProviderMock.Setup(x => x.GetProductTypeById(product.ProductTypeId)).ReturnsAsync(productType);
            _surchargeServiceMock.Setup(x => x.GetById(product.ProductTypeId)).Returns(surcharge);

            var result = _insuranceService.CalculateProductInsurance(product.Id);

            var okResult = Assert.IsType<Task<InsuranceDto>>(result);
            Assert.Equal(insurance.InsuranceValue, result.Result.InsuranceValue);
        }

        [Theory]
        [ClassData(typeof(InsuranceServiceOrderDatas))]
        public void InsuranceService_WhenRequestContainsOrder_ShouldReturnExpectedInsurance(OrderInsuranceRequest orderRequest,List<ProductDto> products, List<ProductTypeDto> productTypes, List<SurchargeDto> surcharges, InsuranceDto insurance)
        {
            _productProviderMock.Setup(x => x.GetProducts()).ReturnsAsync(products);
            _productTypeProviderMock.Setup(x => x.GetProductTypes()).ReturnsAsync(productTypes);
            _surchargeServiceMock.Setup(x => x.GetAll()).Returns(surcharges);

            var result = _insuranceService.CalculateOrderInsurance(orderRequest.Adapt<OrderDto>());

            var okResult = Assert.IsType<Task<InsuranceDto>>(result);
            Assert.Equal(insurance.InsuranceValue, result.Result.InsuranceValue);
        }

        [Fact]
        public void InsuranceService_WhenProductProviderIsNull_ShouldThrowArgumentNullException()
        {
            IProductProvider productProvider = null;

            var exception = Assert.Throws<ArgumentNullException>(() => new InsuranceService(productProvider, _productTypeProviderMock.Object, _surchargeServiceMock.Object, _calculateHandlers));

            Assert.Equal(nameof(productProvider), exception.ParamName);
            Assert.Equal($"Value cannot be null. (Parameter '{nameof(productProvider)}')", exception.Message);
        }

        [Fact]
        public void InsuranceService_WhenProductTypeProviderIsNull_ShouldThrowArgumentNullException()
        {
            IProductTypeProvider productTypeProvider = null;

            var exception = Assert.Throws<ArgumentNullException>(() => new InsuranceService(_productProviderMock.Object, productTypeProvider, _surchargeServiceMock.Object, _calculateHandlers));

            Assert.Equal(nameof(productTypeProvider), exception.ParamName);
            Assert.Equal($"Value cannot be null. (Parameter '{nameof(productTypeProvider)}')", exception.Message);
        }

        [Fact]
        public void InsuranceService_WhenSurchargeProviderIsNull_ShouldThrowArgumentNullException()
        {
            ISurchargeService surchargeService = null;

            var exception = Assert.Throws<ArgumentNullException>(() => new InsuranceService(_productProviderMock.Object, _productTypeProviderMock.Object, surchargeService, _calculateHandlers));

            Assert.Equal(nameof(surchargeService), exception.ParamName);
            Assert.Equal($"Value cannot be null. (Parameter '{nameof(surchargeService)}')", exception.Message);
        }

        [Fact]
        public void InsuranceService_WhenCalculateHandlersProviderIsNull_ShouldThrowArgumentNullException()
        {
            List<IInsuranceCalculateHandler> calculateHandlers = null;

            var exception = Assert.Throws<ArgumentNullException>(() => new InsuranceService(_productProviderMock.Object, _productTypeProviderMock.Object, _surchargeServiceMock.Object, calculateHandlers));

            Assert.Equal("source", exception.ParamName);
            Assert.Equal($"Value cannot be null. (Parameter 'source')", exception.Message);
        }
    }
}