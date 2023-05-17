using Insurance.Application.Handlers;
using Insurance.Domain.Dtos;
using Insurance.Domain.Interfaces.Handlers;
using Insurance.Tests.DataGenerators.Handlers.SalesPrice;
using Xunit;

namespace Insurance.Tests.UnitTests.Handlers
{
    public class SalesPriceTests
    {
        private readonly IInsuranceCalculateHandler _salesPriceHandler;
        public SalesPriceTests()
        {
            _salesPriceHandler = new SalesPriceHandler();
        }

        [Theory]
        [ClassData(typeof(SalesPriceSingleOrderDatas))]
        public void SalesPriceHandler_WhenOrderHasSingleOrderItem_ShouldReturnExpectedInsurance(OrderDto orderDto, InsuranceDto insuranceDto)
        {
            _salesPriceHandler.HandleRequest(orderDto);

            Assert.Equal(insuranceDto.InsuranceValue, orderDto.GetTotalInsuranceValue());
        }

        [Theory]
        [ClassData(typeof(SalesPriceMultipleOrderDatas))]
        public void SalesPriceHandler_WhenOrderHasMultipleOrderItem_ShouldReturnExpectedInsurance(OrderDto orderDto, InsuranceDto insuranceDto)
        {
            _salesPriceHandler.HandleRequest(orderDto);

            Assert.Equal(insuranceDto.InsuranceValue, orderDto.GetTotalInsuranceValue());
        }
    }
}