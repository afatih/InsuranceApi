using Insurance.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Interfaces.Providers
{
    public interface IProductProvider
    {
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int id);
    }
}
