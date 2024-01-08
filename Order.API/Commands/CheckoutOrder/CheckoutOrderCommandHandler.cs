using AutoMapper;
using MediatR;
using Order.API.Dtos;
using Order.API.Repositories;

namespace Order.API.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, OrderDto>
    {
        private readonly IOrderAsyncRepository orderAsyncRepository;
        private readonly IMapper mapper;
        public CheckoutOrderCommandHandler(IOrderAsyncRepository orderAsyncRepository,
            IMapper mapper)
        {
            this.orderAsyncRepository = orderAsyncRepository;
            this.mapper = mapper;
        }

        public async Task<OrderDto> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var order = mapper.Map<Models.Order>(request);
            await orderAsyncRepository.AddAsync(order);
            return mapper.Map<OrderDto>(order);
        }
    }
}
