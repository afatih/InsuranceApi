using Insurance.Domain.Dtos;
using Insurance.Domain.Interfaces.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Handlers
{
    public abstract class InsuranceCalculateHandler : IInsuranceCalculateHandler
    {
        private IInsuranceCalculateHandler _nextHandler;
        public virtual void SetNextHandler(IInsuranceCalculateHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }
        public virtual void HandleRequest(OrderDto orderDto)
        {
            if (_nextHandler!=null)
            {
                _nextHandler.HandleRequest(orderDto);
            }
        }
    }
}
