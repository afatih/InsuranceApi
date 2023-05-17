
namespace Insurance.Domain.Dtos
{
    public class OrderItemDto
    {
        public OrderItemDto()
        {

        }
        public OrderItemDto(ProductDto productDto,bool canBeInsured, int quantity, double surchargeRate)
        {
            ProductId = productDto.Id;
            SalesPrice = productDto.SalesPrice;
            ProductTypeId = productDto.ProductTypeId;
            CanBeInsured = canBeInsured;
            Quantity = quantity;
            SurchargeRate = surchargeRate;
        }

        public OrderItemDto(double surchargeRate, double insuranceValue)
        {
            SurchargeRate = surchargeRate;
            InsuranceValue = insuranceValue;
        }

        public int ProductId { get; private set; }

        public double SalesPrice { get; private set; }

        public int ProductTypeId { get;private set; }
        
        public bool CanBeInsured { get; private set; }

        public int Quantity { get; private set; }

        public double SurchargeRate { get; set; }

        public double InsuranceValue { get; set; }

        public void AddInsuranceValue(double insuranceValue) => InsuranceValue += insuranceValue;
    }
}