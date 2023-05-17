using Insurance.Domain.Dtos;
using System.Collections.Generic;
using Xunit;

namespace Insurance.Tests.DataGenerators.Handlers.SalesPrice
{
    public class SalesPriceSingleOrderDatas : TheoryData<OrderDto, InsuranceDto>
    {
        public SalesPriceSingleOrderDatas()
        {
            Add(new OrderDto(new OrderItemDto(new ProductDto(1, "Product1", 200, 1), true, quantity: 1, surchargeRate: 0)),
                new InsuranceDto(0));

            Add(new OrderDto(new OrderItemDto(new ProductDto(2, "Product2", 500, 1), true, quantity: 1, surchargeRate: 0)), 
                new InsuranceDto(1000));

            Add(new OrderDto(new OrderItemDto(new ProductDto(2, "Product2", 1200, 1), false, quantity: 1, surchargeRate: 0)),
                new InsuranceDto(1000));

            Add(new OrderDto(new OrderItemDto(new ProductDto(2, "Product2", 2000, 1), true, quantity: 1, surchargeRate: 0)),
                new InsuranceDto(2000));

            Add(new OrderDto(new OrderItemDto(new ProductDto(3, "Product3", 4000, 1), true, quantity: 1, surchargeRate: 0)),
                new InsuranceDto(2000));
        }
    }
}