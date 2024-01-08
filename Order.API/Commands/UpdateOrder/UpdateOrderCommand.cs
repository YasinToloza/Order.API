using MediatR;

namespace Order.API.Commands.UpdateOrder
{
    public class UpdateOrderCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string? AddressLine { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
