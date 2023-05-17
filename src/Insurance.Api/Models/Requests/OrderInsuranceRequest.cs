using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Api.Models.Requests
{
    public class OrderInsuranceRequest
    {

        [Required]
        public List<OrderItemRequest> OrderItems { get; set; }
    }
}
