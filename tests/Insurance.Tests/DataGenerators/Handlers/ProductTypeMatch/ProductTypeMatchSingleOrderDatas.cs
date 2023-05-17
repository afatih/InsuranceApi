using Insurance.Domain.Dtos;
using Insurance.Domain.Enums;
using Xunit;

namespace Insurance.Tests.DataGenerators.Handlers.ProductTypeMatch
{
    public class ProductTypeMatchSingleOrderDatas : TheoryData<OrderDto, InsuranceDto>
    {
        public ProductTypeMatchSingleOrderDatas()
        {
            Add(new OrderDto(new OrderItemDto(new ProductDto(1, "Product1", 100, (int)ProductTypeEnum.MP3Players), true, quantity: 1, surchargeRate: 0)),
                new InsuranceDto(0));

            Add(new OrderDto(new OrderItemDto(new ProductDto(2, "Product2", 100, (int)ProductTypeEnum.DigitalCameras), true, quantity: 1, surchargeRate: 0)),
                new InsuranceDto(0));

            Add(new OrderDto(new OrderItemDto(new ProductDto(3, "Product3", 100, (int)ProductTypeEnum.Laptops), true, quantity: 1, surchargeRate: 0)),
                new InsuranceDto(500));

            Add(new OrderDto(new OrderItemDto(new ProductDto(4, "Product4", 100, (int)ProductTypeEnum.Smartphones), true, quantity: 1, surchargeRate: 0)),
                new InsuranceDto(500));
        }
    }
}