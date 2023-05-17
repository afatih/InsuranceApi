namespace Insurance.Domain.Dtos
{
    public class ProductTypeDto
    {
        public ProductTypeDto(int id, string name, bool canBeInsured)
        {
            Id = id;
            Name = name;
            CanBeInsured = canBeInsured;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanBeInsured { get; set; }
    }
}