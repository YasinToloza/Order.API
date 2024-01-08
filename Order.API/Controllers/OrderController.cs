using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.API.Commands.CheckoutOrder;
using Order.API.Commands.UpdateOrder;
using Order.API.Queries.GetorderByUserName;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IValidator<CheckoutOrderCommand> checkoutValidator;
        private readonly IValidator<UpdateOrderCommand> updateValidator;

        public OrderController(IMediator mediator,
            IValidator<CheckoutOrderCommand> checkoutValidator,
            IValidator<UpdateOrderCommand> updateValidator)
        {
            this.mediator = mediator;
            this.checkoutValidator = checkoutValidator;
            this.updateValidator = updateValidator;
        }

        [HttpGet]
        [Route("GetOrderByUserName/{userName}")]
        public async Task<IActionResult> GetOrderByUserName(string userName)
        {
            return Ok(await mediator.Send(
                new GetOrderByUserNameQuery() { UserName = userName }));
        }
        [HttpPost]
        [Route("CheckoutOrder")]
        public async Task<IActionResult> CheckoutOrder(CheckoutOrderCommand command)
        {
            var result = checkoutValidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            var result = updateValidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await mediator.Send(command));
        }
    }
}
