using System.ComponentModel.DataAnnotations;

namespace Insurance.Api.Models.Requests
{
    public class OrderItemRequest
    {
        [Required]
        public int ProductId{ get; set; }


        [Required]
        public int Quantity { get; set; }
    }
}
