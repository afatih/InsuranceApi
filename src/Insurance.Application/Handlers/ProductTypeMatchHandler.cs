using Insurance.Domain.Dtos;
using Insurance.Domain.Enums;

namespace Insurance.Application.Handlers
{
    public class ProductTypeMatchHandler : InsuranceCalculateHandler
    {
        public override void HandleRequest(OrderDto orderDto)
        {
            orderDto.OrderItems.ForEach(orderItem =>
            {
                if (orderItem.ProductTypeId == (int)ProductTypeEnum.Smartphones || orderItem.ProductTypeId == (int)ProductTypeEnum.Laptops)
                    orderItem.AddInsuranceValue(500 * orderItem.Quantity);
            });

            base.HandleRequest(orderDto);
        }
    }
}