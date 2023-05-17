using Insurance.Application.Handlers;
using Insurance.Domain.Dtos;
using Insurance.Domain.Interfaces.Handlers;
using Insurance.Tests.DataGenerators.Handlers.ProductTypeMatch;
using Xunit;

namespace Insurance.Tests.UnitTests.Handlers
{
    public class ProductTypeMatchTests
    {
        private readonly IInsuranceCalculateHandler _productTypeMatchHandler;

        public ProductTypeMatchTests()
        {
            _productTypeMatchHandler = new ProductTypeMatchHandler();
        }

        [Theory]
        [ClassData(typeof(ProductTypeMatchSingleOrderDatas))]
        public void ProductTypeMatchHandler_WhenOrderHasSingleOrderItem_ShouldReturnExpectedInsurance(OrderDto orderDto, InsuranceDto insuranceDto)
        {
            _productTypeMatchHandler.HandleRequest(orderDto);

            Assert.Equal(insuranceDto.InsuranceValue, orderDto.GetTotalInsuranceValue());
        }

        [Theory]
        [ClassData(typeof(ProductTypeMatchMultipleOrderDatas))]
        public void ProductTypeMatchHandler_WhenOrderHasMultipleOrderItem_ShouldReturnExpectedInsurance(OrderDto orderDto, InsuranceDto insuranceDto)
        {
            _productTypeMatchHandler.HandleRequest(orderDto);

            Assert.Equal(insuranceDto.InsuranceValue, orderDto.GetTotalInsuranceValue());
        }
    }
}