using Insurance.Domain.Dtos;
using System.Collections.Generic;
using Xunit;

namespace Insurance.Tests.DataGenerators.Handlers.SalesPrice
{
    public class SalesPriceMultipleOrderDatas : TheoryData<OrderDto, InsuranceDto>
    {
        public SalesPriceMultipleOrderDatas()
        {
            var order1 = new OrderDto();
            order1.OrderItems.Add(new OrderItemDto(new ProductDto(1, "Product1", 100, 1), true, quantity: 2, surchargeRate: 0));
            order1.OrderItems.Add(new OrderItemDto(new ProductDto(2, "Product2", 499, 1), true, quantity: 3, surchargeRate: 0));
            Add(order1, new InsuranceDto(0));


            var order2 = new OrderDto();
            order2.OrderItems.Add(new OrderItemDto(new ProductDto(1, "Product1", 500, 1), true, quantity: 2, surchargeRate: 0));
            order2.OrderItems.Add(new OrderItemDto(new ProductDto(2, "Product2", 600, 1), true, quantity: 3, surchargeRate: 0));
            Add(order2, new InsuranceDto(5000));


            var order3 = new OrderDto();
            order3.OrderItems.Add(new OrderItemDto(new ProductDto(1, "Product1", 2000, 1), true, quantity: 2, surchargeRate: 0));
            order3.OrderItems.Add(new OrderItemDto(new ProductDto(2, "Product2", 2500, 1), true, quantity: 3, surchargeRate: 0));
            Add(order3, new InsuranceDto(10000));
        }
    }
}