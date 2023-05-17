using Insurance.Domain.Dtos;
using Xunit;

namespace Insurance.Tests.DataGenerators.Handlers.Surcharge
{
    public class SurchargeSingleOrderDatas : TheoryData<OrderDto, InsuranceDto>
    {
        public SurchargeSingleOrderDatas()
        {
            Add(new OrderDto(new OrderItemDto(surchargeRate: 10, insuranceValue: 0)),
                new InsuranceDto(0));

            Add(new OrderDto(new OrderItemDto(surchargeRate: 0, insuranceValue: 1000)),
                new InsuranceDto(1000));

            Add(new OrderDto(new OrderItemDto(surchargeRate: 10, insuranceValue: 1000)),
                new InsuranceDto(1100));

            Add(new OrderDto(new OrderItemDto(surchargeRate: 20, insuranceValue: 2500)),
                new InsuranceDto(3000));
        }
    }
}