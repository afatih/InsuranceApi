using Insurance.Domain.Dtos;

namespace Insurance.Domain.Interfaces.Providers
{
    public interface IProductTypeProvider
    {
        Task<List<ProductTypeDto>> GetProductTypes();

        Task<ProductTypeDto> GetProductTypeById(int id);
    }
}