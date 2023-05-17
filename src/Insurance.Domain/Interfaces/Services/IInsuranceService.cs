using Insurance.Domain.Dtos;

namespace Insurance.Domain.Interfaces.Services
{
    public interface IInsuranceService
    {
        Task<InsuranceDto> CalculateProductInsurance(int productId);
        Task<InsuranceDto> CalculateOrderInsurance(OrderDto orderDto);
        Task<InsuranceDto> CalculateInsurance(OrderDto orderDto);
    }
}