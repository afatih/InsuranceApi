using Insurance.Domain.Dtos;
using Insurance.Domain.Enums;
using Xunit;

namespace Insurance.Tests.DataGenerators.Handlers.ProductTypeContains
{
    public class ProductTypeContainsMultipleOrderDatas : TheoryData<OrderDto, InsuranceDto>
    {
        public ProductTypeContainsMultipleOrderDatas()
        {
            var order1 = new OrderDto();
            order1.OrderItems.Add(new OrderItemDto(new ProductDto(1, "Product1", 100, (int)ProductTypeEnum.MP3Players), true, quantity: 2, surchargeRate: 0));
            order1.OrderItems.Add(new OrderItemDto(new ProductDto(2, "Product2", 100, (int)ProductTypeEnum.Laptops), true, quantity: 3, surchargeRate: 0));
            Add(order1, new InsuranceDto(0));


            var order2 = new OrderDto();
            order2.OrderItems.Add(new OrderItemDto(new ProductDto(1, "Product1", 100, (int)ProductTypeEnum.MP3Players), true, quantity: 2, surchargeRate: 0));
            order2.OrderItems.Add(new OrderItemDto(new ProductDto(2, "Product2", 100, (int)ProductTypeEnum.DigitalCameras), true, quantity: 1, surchargeRate: 0));
            Add(order2, new InsuranceDto(500));


            var order3 = new OrderDto();
            order3.OrderItems.Add(new OrderItemDto(new ProductDto(1, "Product1", 100, (int)ProductTypeEnum.Laptops), true, quantity: 2, surchargeRate: 0));
            order3.OrderItems.Add(new OrderItemDto(new ProductDto(2, "Product2", 100, (int)ProductTypeEnum.DigitalCameras), true, quantity: 3, surchargeRate: 0));
            Add(order3, new InsuranceDto(500));
        }
    }
}