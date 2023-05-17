using Insurance.Domain.Dtos;

namespace Insurance.Application.Handlers
{
    public class SurchargeHandler : InsuranceCalculateHandler
    {
        public override void HandleRequest(OrderDto orderDto)
        {
            orderDto.OrderItems.ForEach(orderItem =>
            {
                if (orderItem.InsuranceValue != 0)
                    orderItem.AddInsuranceValue(orderItem.InsuranceValue * (orderItem.SurchargeRate/100));
            });

            base.HandleRequest(orderDto);
        }
    }
}