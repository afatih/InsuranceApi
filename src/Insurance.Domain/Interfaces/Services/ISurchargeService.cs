using Insurance.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Interfaces.Services
{
    public interface ISurchargeService
    {
        void Add(SurchargeDto surchargeDto);
        SurchargeDto GetById(int id);
        List<SurchargeDto> GetAll();
        void Delete(int id);
        void Update(SurchargeDto surchargeDto);
    }
}
