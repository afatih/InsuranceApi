using Insurance.Application.Handlers;
using Insurance.Domain.Dtos;
using Insurance.Domain.Interfaces.Handlers;
using Insurance.Tests.DataGenerators.Handlers.Surcharge;
using Xunit;

namespace Insurance.Tests.UnitTests.Handlers
{
    public class SurchargeTests
    {
        private readonly IInsuranceCalculateHandler _surchargeHandler;

        public SurchargeTests()
        {
            _surchargeHandler = new SurchargeHandler();
        }

        [Theory]
        [ClassData(typeof(SurchargeSingleOrderDatas))]
        public void SurchargeHandler_WhenOrderHasSingleOrderItem_ShouldReturnExpectedInsurance(OrderDto orderDto, InsuranceDto insuranceDto)
        {
            _surchargeHandler.HandleRequest(orderDto);

            Assert.Equal(insuranceDto.InsuranceValue, orderDto.GetTotalInsuranceValue());
        }

        [Theory]
        [ClassData(typeof(SurchargeMultipleOrderDatas))]
        public void SurchargeHandler_WhenOrderHasMultipleOrderItem_ShouldReturnExpectedInsurance(OrderDto orderDto, InsuranceDto insuranceDto)
        {
            _surchargeHandler.HandleRequest(orderDto);

            Assert.Equal(insuranceDto.InsuranceValue, orderDto.GetTotalInsuranceValue());
        }
    }
}