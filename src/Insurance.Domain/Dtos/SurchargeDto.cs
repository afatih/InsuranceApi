using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Dtos
{
    public class SurchargeDto
    {
        public SurchargeDto(int productTypeId, double rate)
        {
            ProductTypeId = productTypeId;
            Rate = rate;
        }

        public int ProductTypeId { get; set; }
        public double Rate { get; set; }
    }
}
