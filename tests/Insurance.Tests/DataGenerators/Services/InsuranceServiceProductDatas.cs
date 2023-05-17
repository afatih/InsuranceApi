using Insurance.Domain.Dtos;
using Insurance.Domain.Enums;
using Xunit;

namespace Insurance.Tests.DataGenerators.Services
{
    public class InsuranceServiceProductDatas : TheoryData<ProductDto, ProductTypeDto, SurchargeDto, InsuranceDto>
    {
        public InsuranceServiceProductDatas()
        {
            var product1TypeId = (int)ProductTypeEnum.MP3Players;
            Add(new ProductDto(1, "Product1", 200, product1TypeId),
                new ProductTypeDto(product1TypeId, "ProductType1", true),
                new SurchargeDto(product1TypeId, 10),
                new InsuranceDto(0));

            var product2TypeId = (int)ProductTypeEnum.Laptops;
            Add(new ProductDto(1, "Product1", 600, product2TypeId),
                new ProductTypeDto(product2TypeId, "ProductType1", true),
                new SurchargeDto(product2TypeId, 20),
                new InsuranceDto(1800));

            var product3TypeId = (int)ProductTypeEnum.Smartphones;
            Add(new ProductDto(1, "Product1", 2000, product3TypeId),
                new ProductTypeDto(product3TypeId, "ProductType1", true),
                new SurchargeDto(product3TypeId, 50),
                new InsuranceDto(3750));

            var product4TypeId = (int)ProductTypeEnum.DigitalCameras;
            Add(new ProductDto(1, "Product1", 4000, product4TypeId),
                new ProductTypeDto(product4TypeId, "ProductType1", true),
                new SurchargeDto(product4TypeId, 0),
                new InsuranceDto(2500));
        }
    }
}