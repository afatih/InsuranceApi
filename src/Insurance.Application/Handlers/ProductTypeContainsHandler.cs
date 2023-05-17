using Insurance.Domain.Dtos;
using Insurance.Domain.Enums;
using Insurance.Domain.Interfaces;

namespace Insurance.Application.Handlers
{
    public class ProductTypeContainsHandler : InsuranceCalculateHandler
    {
        public override void HandleRequest(OrderDto orderDto)
        {
            var digitalCamera = orderDto.OrderItems.FirstOrDefault(c => c.ProductTypeId == (int)ProductTypeEnum.DigitalCameras);

            if (digitalCamera!=null && digitalCamera.Quantity > 0)
                orderDto.AddInsuranceValue(500);

            base.HandleRequest(orderDto);
        }
    }
}
