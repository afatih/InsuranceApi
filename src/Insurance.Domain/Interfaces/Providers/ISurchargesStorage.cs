using Insurance.Domain.Dtos;
using Insurance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Interfaces.Providers
{
    public interface ISurchargesStorage
    {
        void Add(Surcharge surcharge);

        Surcharge GetById(int productTypeId);

        List<Surcharge> GetAll();

        void Delete(int productTypeId);

        void Update(Surcharge surcharge);
    }
}
