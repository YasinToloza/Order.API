using FluentValidation;

namespace Order.API.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator:AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator() 
        {
            RuleFor(order => order.AddressLine)
                .NotNull()
                .NotEmpty();

            RuleFor(order => order.Country)
                .NotNull()
                .NotEmpty();

            RuleFor(order => order.ZipCode)
                 .NotNull()
                 .NotEmpty();

            RuleFor(order => order.State)
                 .NotNull()
                 .NotEmpty();

        }
    }
}
