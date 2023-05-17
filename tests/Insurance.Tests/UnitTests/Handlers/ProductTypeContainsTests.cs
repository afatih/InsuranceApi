using Insurance.Application.Handlers;
using Insurance.Domain.Dtos;
using Insurance.Domain.Interfaces.Handlers;
using Insurance.Tests.DataGenerators.Handlers.ProductTypeContains;
using Xunit;

namespace Insurance.Tests.UnitTests.Handlers
{
    public class ProductTypeContainsTests
    {
        private readonly IInsuranceCalculateHandler _productTypeContainsHandler;

        public ProductTypeContainsTests()
        {
            _productTypeContainsHandler = new ProductTypeContainsHandler();
        }

        [Theory]
        [ClassData(typeof(ProductTypeContainsSingleOrderDatas))]
        public void ProductTypeContainsHandler_WhenOrderHasSingleOrderItem_ShouldReturnExpectedInsurance(OrderDto orderDto, InsuranceDto insuranceDto)
        {
            _productTypeContainsHandler.HandleRequest(orderDto);

            Assert.Equal(insuranceDto.InsuranceValue, orderDto.GetTotalInsuranceValue());
        }

        [Theory]
        [ClassData(typeof(ProductTypeContainsMultipleOrderDatas))]
        public void ProductTypeContainsHandler_WhenOrderHasMultipleOrderItem_ShouldReturnExpectedInsurance(OrderDto orderDto, InsuranceDto insuranceDto)
        {
            _productTypeContainsHandler.HandleRequest(orderDto);

            Assert.Equal(insuranceDto.InsuranceValue, orderDto.GetTotalInsuranceValue());
        }
    }
}