using System.ComponentModel.DataAnnotations;

namespace Insurance.Api.Models.Requests
{
    public class SurchargeRequest
    {
        [Required]
        public int ProductTypeId { get; set; }

        [Required]
        [Range(0,100)]
        public double Rate { get; set; }
    }
}
