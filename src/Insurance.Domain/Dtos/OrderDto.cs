using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Dtos
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderItems = new List<OrderItemDto>();
        }

        public OrderDto(OrderItemDto orderItemDto)
        {
            OrderItems = new List<OrderItemDto>
            {
               orderItemDto
            };
        }

        public List<OrderItemDto> OrderItems { get; set; }

        public int OrderInsuranceValue { get; private set; }

        public void AddInsuranceValue(int cost) => OrderInsuranceValue += cost;

        public double GetTotalInsuranceValue()
        {
            return OrderItems.Sum(c => c.InsuranceValue) + OrderInsuranceValue;
        }

    }
}
