using System.ComponentModel.DataAnnotations;

namespace Insurance.Api.Models.Requests
{
    public class ProductInsuranceRequest
    {
        [Required]
        public int ProductId { get; set; }
    }
}
