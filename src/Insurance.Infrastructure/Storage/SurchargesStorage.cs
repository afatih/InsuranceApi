using Insurance.Domain.Entities;
using Insurance.Domain.Exceptions;
using Insurance.Domain.Interfaces.Providers;
using System.Collections.Concurrent;

namespace Insurance.Infrastructure.Storage
{
    public class SurchargesStorage : ISurchargesStorage
    {
        public ConcurrentDictionary<int, Surcharge> Surcharges { get; } = new ConcurrentDictionary<int, Surcharge>();

        public SurchargesStorage()
        {
            AddSeedData();
        }

        public void Add(Surcharge surcharge)
        {
            if (!Surcharges.TryAdd(surcharge.ProductTypeId, surcharge))
            {
                throw new GlobalException($"Surcharge allready exist. ProductTypeId : {surcharge.ProductTypeId}");
            }
        }

        public Surcharge GetById(int productTypeId)
        {
            if (!Surcharges.TryGetValue(productTypeId, out var surcharge))
            {
                return new Surcharge { ProductTypeId = productTypeId };
            }

            return surcharge;
        }

        public List<Surcharge> GetAll()
        {
            return Surcharges.Values.ToList();
        }

        public void Delete(int productTypeId)
        {
            if (!Surcharges.TryRemove(productTypeId, out var surcharge))
            {
                throw new GlobalException($"Surcharge not found. ProductTypeId : {productTypeId}");
            }
        }

        public void Update(Surcharge surcharge)
        {
            var oldSurcharge = GetById(surcharge.ProductTypeId);
            if (!Surcharges.TryUpdate(surcharge.ProductTypeId, surcharge, oldSurcharge))
            {
                throw new GlobalException($"Surcharge not found. ProductTypeId : {surcharge.ProductTypeId}");
            }
        }

        private void AddSeedData()
        {
            Add(new Surcharge { ProductTypeId = 21, Rate = 10 });
            Add(new Surcharge { ProductTypeId = 32, Rate = 20 });
            Add(new Surcharge { ProductTypeId = 33, Rate = 30 });
            Add(new Surcharge { ProductTypeId = 35, Rate = 40 });
            Add(new Surcharge { ProductTypeId = 12, Rate = 50 });
        }
    }
}