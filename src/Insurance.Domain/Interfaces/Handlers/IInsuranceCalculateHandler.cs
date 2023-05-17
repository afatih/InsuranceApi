using Insurance.Domain.Dtos;

namespace Insurance.Domain.Interfaces.Handlers
{
    public interface IInsuranceCalculateHandler
    {
        void SetNextHandler(IInsuranceCalculateHandler nextHandler);

        void HandleRequest(OrderDto orderDto);
    }
}