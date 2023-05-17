using Insurance.Domain.Dtos;
using Insurance.Domain.Exceptions;
using Insurance.Domain.Interfaces.Providers;
using Newtonsoft.Json;
using System.Net;

namespace Insurance.Infrastructure.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly HttpClient _httpClient;

        public ProductProvider(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient(nameof(ProductProvider));
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var result = await _httpClient.GetAsync($"/products/{id}");
           
            if (!result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new GlobalException($"Product not found. ProductId : {id}");
                }
                else
                {
                    throw new GlobalException("An error occurred while calling the external API. Status code: " + result.StatusCode + " - " + content);
                }
            }

            var responseJson = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductDto>(responseJson);
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var result = await _httpClient.GetAsync($"/products");

            if (!result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();

                if (result.StatusCode == HttpStatusCode.NotFound )
                {
                    throw new GlobalException("Product not found.");
                }
                else
                {
                    throw new GlobalException("An error occurred while calling the external API. Status code: " + result.StatusCode + " - " + content);
                }
            }

            var responseJson = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProductDto>>(responseJson);
        }
    }
}