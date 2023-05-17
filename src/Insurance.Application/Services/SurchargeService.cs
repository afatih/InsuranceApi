using Insurance.Domain.Dtos;
using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces.Providers;
using Insurance.Domain.Interfaces.Services;
using Mapster;

namespace Insurance.Application.Services
{
    public class SurchargeService : ISurchargeService
    {
        private readonly ISurchargesStorage _surchargesStorage;

        public SurchargeService(ISurchargesStorage surchargesStorage)
        {
            _surchargesStorage = surchargesStorage;
        }

        public List<SurchargeDto> GetAll()
        {
            return _surchargesStorage.GetAll().Adapt<List<SurchargeDto>>();
        }

        public SurchargeDto GetById(int id)
        {
            return _surchargesStorage.GetById(id).Adapt<SurchargeDto>();
        }

        public void Add(SurchargeDto surchargeDto)
        {
            _surchargesStorage.Add(surchargeDto.Adapt<Surcharge>());
        }
        public void Update(SurchargeDto surchargeDto)
        {
            _surchargesStorage.Update(surchargeDto.Adapt<Surcharge>());
        }

        public void Delete(int id)
        {
            _surchargesStorage.Delete(id);
        }
    }
}