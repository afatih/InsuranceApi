using Insurance.Domain.Dtos;

namespace Insurance.Application.Handlers
{
    public class SalesPriceHandler : InsuranceCalculateHandler
    {
        public override void HandleRequest(OrderDto orderDto)
        {
            orderDto.OrderItems.ForEach(orderItem =>
            {
                if (orderItem.SalesPrice >= 500 && orderItem.SalesPrice < 2000)
                    orderItem.AddInsuranceValue(1000 * orderItem.Quantity);
                else if (orderItem.SalesPrice >= 2000)
                    orderItem.AddInsuranceValue(2000 * orderItem.Quantity);
            });

            base.HandleRequest(orderDto);
        }
    }
}