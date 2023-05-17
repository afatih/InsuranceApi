using Insurance.Domain.Dtos;
using Insurance.Domain.Exceptions;
using Insurance.Domain.Interfaces.Handlers;
using Insurance.Domain.Interfaces.Providers;
using Insurance.Domain.Interfaces.Services;

namespace Insurance.Application.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IProductProvider _productProvider;
        private readonly IProductTypeProvider _productTypeProvider;
        private readonly ISurchargeService _surchargeService;
        private readonly List<IInsuranceCalculateHandler> _calculateHandlers;

        public InsuranceService(IProductProvider productProvider,
            IProductTypeProvider productTypeProvider,
            ISurchargeService surchargeService,
            IEnumerable<IInsuranceCalculateHandler> calculateHandlers)
        {
            _productProvider = productProvider ?? throw new ArgumentNullException(nameof(productProvider));
            _productTypeProvider = productTypeProvider ?? throw new ArgumentNullException(nameof(productTypeProvider));
            _surchargeService = surchargeService ?? throw new ArgumentNullException(nameof(surchargeService));
            _calculateHandlers = calculateHandlers.ToList() ?? throw new ArgumentNullException(nameof(calculateHandlers));
        }

        public async Task<InsuranceDto> CalculateProductInsurance(int productId)
        {
            var product = await _productProvider.GetProductById(productId);
            var productType = await _productTypeProvider.GetProductTypeById(product.ProductTypeId);
            var surcharge = _surchargeService.GetById(productType.Id);

            if (!productType.CanBeInsured)
                return new InsuranceDto(default(int));

            var orderDto = new OrderDto(new OrderItemDto(product, productType.CanBeInsured, 1, surcharge.Rate));

            return await CalculateInsurance(orderDto);
        }

        public async Task<InsuranceDto> CalculateOrderInsurance(OrderDto orderDto)
        {
            var products = await _productProvider.GetProducts();
            var productTypes = await _productTypeProvider.GetProductTypes();
            var surcharges = _surchargeService.GetAll();

            orderDto.OrderItems = products
                .Join(orderDto.OrderItems, product => product.Id, orderItem => orderItem.ProductId, (product, orderItem) => new { product, orderItem })
                .Join(productTypes, p => p.product.ProductTypeId, pt => pt.Id, (p, pt) => new { p.product, p.orderItem, pt })
                .Join(surcharges, pt => pt.pt.Id, s => s.ProductTypeId, (pt, s) => new OrderItemDto(pt.product, pt.pt.CanBeInsured, pt.orderItem.Quantity, s.Rate))
                .Where(dto => dto.CanBeInsured)
                .ToList();

            return await CalculateInsurance(orderDto);
        }

        public async Task<InsuranceDto> CalculateInsurance(OrderDto orderDto)
        {
            IInsuranceCalculateHandler previousHandler = null;
            foreach (var handler in _calculateHandlers)
            {
                if (previousHandler != null)
                {
                    previousHandler.SetNextHandler(handler);
                }
                previousHandler = handler;
            }

            _calculateHandlers.First().HandleRequest(orderDto);

            return new InsuranceDto(orderDto.GetTotalInsuranceValue());
        }
    }
}