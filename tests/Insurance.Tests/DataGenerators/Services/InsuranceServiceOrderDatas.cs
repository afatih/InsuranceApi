using Insurance.Api.Models.Requests;
using Insurance.Domain.Dtos;
using Insurance.Domain.Enums;
using Mapster;
using System.Collections.Generic;
using Xunit;

namespace Insurance.Tests.DataGenerators.Services
{
    public class InsuranceServiceOrderDatas : TheoryData<OrderInsuranceRequest,List<ProductDto>,List<ProductTypeDto>,List<SurchargeDto>,InsuranceDto>
    {
        private  List<ProductDto> _defaultProducts;
        private  List<ProductTypeDto> _defaultProductTypes;
        private  List<SurchargeDto> _defaultSurcharges;
        public InsuranceServiceOrderDatas()
        {
            SeedDefaultDatas();

            var orderRequest1 = new OrderInsuranceRequest
            {
                OrderItems = new List<OrderItemRequest>
                {
                    new OrderItemRequest { ProductId=1,Quantity=1},
                    new OrderItemRequest { ProductId=2,Quantity=2},
                }
            };
            Add(orderRequest1, _defaultProducts, _defaultProductTypes, _defaultSurcharges, new InsuranceDto(2400));

            var orderRequest2 = new OrderInsuranceRequest
            {
                OrderItems = new List<OrderItemRequest>
                {
                    new OrderItemRequest { ProductId=3,Quantity=2},
                    new OrderItemRequest { ProductId=4,Quantity=1},
                }
            };
            Add(orderRequest2, _defaultProducts, _defaultProductTypes, _defaultSurcharges, new InsuranceDto(7400));

            var orderRequest3 = new OrderInsuranceRequest
            {
                OrderItems = new List<OrderItemRequest>
                {
                    new OrderItemRequest { ProductId=4,Quantity=1},
                    new OrderItemRequest { ProductId=5,Quantity=3},
                }
            };
            Add(orderRequest3, _defaultProducts, _defaultProductTypes, _defaultSurcharges, new InsuranceDto(10000));
        }

        public void SeedDefaultDatas()
        {
            _defaultProducts = new List<ProductDto>
            {
                new ProductDto(1,"Product1",100,(int)ProductTypeEnum.MP3Players),
                new ProductDto(2,"Product2",500,(int)ProductTypeEnum.Washingmachines),
                new ProductDto(3,"Product3",1500,(int)ProductTypeEnum.Laptops),
                new ProductDto(4,"Product4",2000,(int)ProductTypeEnum.Smartphones),
                new ProductDto(5,"Product5",2500,(int)ProductTypeEnum.DigitalCameras)
            };

            _defaultProductTypes = new List<ProductTypeDto>
            {
                new ProductTypeDto((int)ProductTypeEnum.MP3Players,nameof(ProductTypeEnum.MP3Players),true),
                new ProductTypeDto((int)ProductTypeEnum.Washingmachines,nameof(ProductTypeEnum.Washingmachines),true),
                new ProductTypeDto((int)ProductTypeEnum.Laptops,nameof(ProductTypeEnum.Laptops),true),
                new ProductTypeDto((int)ProductTypeEnum.Smartphones,nameof(ProductTypeEnum.Smartphones),true),
                new ProductTypeDto((int)ProductTypeEnum.DigitalCameras,nameof(ProductTypeEnum.DigitalCameras),true),
            };

            _defaultSurcharges = new List<SurchargeDto>
            {
                new SurchargeDto((int)ProductTypeEnum.MP3Players,10),
                new SurchargeDto((int)ProductTypeEnum.Washingmachines,20),
                new SurchargeDto((int)ProductTypeEnum.Laptops,30),
                new SurchargeDto((int)ProductTypeEnum.Smartphones,40),
                new SurchargeDto((int)ProductTypeEnum.DigitalCameras,0),
            };
        }
    }
}