using Insurance.Domain.Dtos;
using Xunit;

namespace Insurance.Tests.DataGenerators.Handlers.Surcharge
{
    public class SurchargeMultipleOrderDatas : TheoryData<OrderDto, InsuranceDto>
    {
        public SurchargeMultipleOrderDatas()
        {
            var order1 = new OrderDto();
            order1.OrderItems.Add(new OrderItemDto(surchargeRate: 10, insuranceValue: 0));
            order1.OrderItems.Add(new OrderItemDto(surchargeRate: 30, insuranceValue: 0));
            Add(order1, new InsuranceDto(0));

            var order2 = new OrderDto();
            order2.OrderItems.Add(new OrderItemDto(surchargeRate: 10, insuranceValue: 0));
            order2.OrderItems.Add(new OrderItemDto(surchargeRate: 0, insuranceValue: 1000));
            order2.OrderItems.Add(new OrderItemDto(surchargeRate: 30, insuranceValue: 1000));
            Add(order2, new InsuranceDto(2300));

            var order3 = new OrderDto();
            order3.OrderItems.Add(new OrderItemDto(surchargeRate: 0, insuranceValue: 1000));
            order3.OrderItems.Add(new OrderItemDto(surchargeRate: 10, insuranceValue: 1000));
            order3.OrderItems.Add(new OrderItemDto(surchargeRate: 30, insuranceValue: 2000));
            Add(order3, new InsuranceDto(4700));
        }
    }
}