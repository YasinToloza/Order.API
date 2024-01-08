using AutoMapper;
using MediatR;
using Order.API.Repositories;

namespace Order.API.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IOrderAsyncRepository orderAsyncRepository;
        private readonly IMapper mapper;
        public UpdateOrderCommandHandler(IOrderAsyncRepository orderAsyncRepository,
            IMapper mapper)
        {
            this.orderAsyncRepository = orderAsyncRepository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = mapper.Map<Models.Order>(request);
            return await orderAsyncRepository.UpdateAddress(order);
        }
    }
}
