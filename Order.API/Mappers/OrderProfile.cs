using AutoMapper;
using Order.API.Commands.CheckoutOrder;
using Order.API.Commands.UpdateOrder;
using Order.API.Dtos;

namespace Order.API.Mappers
{
    public class OrderProfile:Profile
    {
        public OrderProfile() 
        {
            CreateMap<Models.Order, OrderDto>().ReverseMap();
            CreateMap<Models.Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Models.Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
