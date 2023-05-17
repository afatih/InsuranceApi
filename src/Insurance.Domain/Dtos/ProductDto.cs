namespace Insurance.Domain.Dtos
{
    public class ProductDto
    {
        public ProductDto(int id, string name, double salesPrice, int productTypeId)
        {
            Id = id;
            Name = name;
            SalesPrice = salesPrice;
            ProductTypeId = productTypeId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double SalesPrice { get; set; }
        public int ProductTypeId { get; set; }
    }
}