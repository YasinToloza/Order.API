using FluentValidation;

namespace Order.API.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator:AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator() 
        {
            RuleFor(order => order.UserName)
                .NotNull()
                .NotEmpty().WithMessage("User name is required")
                .MaximumLength(40);

            RuleFor(order => order.FirstName)
                .NotNull()
                .NotEmpty();

            RuleFor(order => order.EmailAddress)
                .NotNull()
                .NotEmpty()
                .EmailAddress();


            RuleFor(order => order.TotalPrice)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
