using Discount.Application.Command;
using Discount.Application.Commands;
using Discount.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

       
        [HttpGet("GetDiscountById")]
        public async Task<IActionResult> GetCoupon([FromQuery] GetDiscountByIdQuery byIdQuery)
        {
          var query=await _mediator.Send(byIdQuery);
            return Ok(query);
        }

       
        [HttpGet("activeDiscounts")]
        public async Task<IActionResult> GetActiveCoupons([FromQuery]GetActiveDiscountsQuery getActive)
        {
            var query = await _mediator.Send(getActive);
            return Ok(query);
           
        }

        
        [HttpPost("apply")]
        public async Task<IActionResult> ApplyCoupon([FromBody] ApplyDiscountCommand command)
        {
            var discountedPrice = await _mediator.Send(command);

            return Ok(new { DiscountedPrice = discountedPrice });
        }

       
        [HttpPost("Create")]
        public async Task<IActionResult> CreateCoupon([FromBody] CreateDiscountCommand command)
        {
            var result = await _mediator.Send(command);

          
            return CreatedAtAction(nameof(GetCoupon), new { id = result }, null);
        }

     
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCoupon(long id)
        {
            var command = new DeleteDiscountCommand { CouponId = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }   }
