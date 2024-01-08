using MediatR;
using Order.API.Dtos;

namespace Order.API.Queries.GetorderByUserName
{
    public class GetOrderByUserNameQuery:IRequest<List<OrderDto>>
    {
        public string? UserName { get; set; }
    }
}
