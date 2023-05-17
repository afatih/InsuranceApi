using Insurance.Domain.Dtos;
using Insurance.Domain.Exceptions;
using Insurance.Domain.Interfaces.Providers;
using Newtonsoft.Json;
using System.Net;

namespace Insurance.Infrastructure.Providers
{
    public class ProductTypeProvider : IProductTypeProvider
    {
        private readonly HttpClient _httpClient;

        public ProductTypeProvider(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient(nameof(ProductProvider));
        }

        public async Task<ProductTypeDto> GetProductTypeById(int id)
        {
            var result = await _httpClient.GetAsync($"/product_types/{id}");

            if (!result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new GlobalException($"Product Type not found. ProductTypeId:{id}");
                }
                else
                {
                    throw new GlobalException("An error occurred while calling the external API. Status code: " + result.StatusCode + " - " + content);
                }
            }

            var responseJson = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductTypeDto>(responseJson);
        }

        public async Task<List<ProductTypeDto>> GetProductTypes()
        {
            var result = await _httpClient.GetAsync($"/product_types");

            if (!result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new GlobalException("Product Type not found.");
                }
                else
                {
                    throw new GlobalException("An error occurred while calling the external API. Status code: " + result.StatusCode + " - " + content);
                }
            }

            var responseJson = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProductTypeDto>>(responseJson);
        }
    }
}