using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Order.API.Dtos;
using Order.API.Repositories;

namespace Order.API.Queries.GetorderByUserName
{
    public class GetOrderByUserNameQueryHandler : IRequestHandler<GetOrderByUserNameQuery,
        List<OrderDto>>
    {
        private readonly IOrderAsyncRepository orderAsyncRepository;
        private readonly IMapper mapper;
        public GetOrderByUserNameQueryHandler(IOrderAsyncRepository orderAsyncRepository,
            IMapper mapper) 
        {
            this.mapper = mapper;
            this.orderAsyncRepository = orderAsyncRepository;
        }

        public async Task<List<OrderDto>> Handle(GetOrderByUserNameQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderAsyncRepository.GetOrderByUserName(request.UserName ?? "");
            return mapper.Map<List<OrderDto>>(orders);
        }
    }
}
