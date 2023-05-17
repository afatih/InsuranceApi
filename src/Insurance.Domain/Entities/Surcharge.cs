using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Entities
{
    public class Surcharge
    {
        public int ProductTypeId { get; set; }
        public double Rate { get; set; }
    }
}
