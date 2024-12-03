using Discount.Application.Commands;
using Discount.Application.Handlers.Command;
using Discount.Application.Helper;
using Discount.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var query = await _mediator.Send(byIdQuery);
            return Ok(query);
        }


        [HttpGet("activeDiscounts")]
        public async Task<IActionResult> GetActiveCoupons([FromQuery] GetActiveDiscountsQuery getActive)
        {
            var query = await _mediator.Send(getActive);
            return Ok(query);

        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateCoupon([FromBody] CreateDiscountCommand command)
        {
            await _mediator.Send(command);


            return Ok(command);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCoupon([FromQuery]DeleteDiscountCommand command)
        {

            await _mediator.Send(command);
          

            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult>UpdateCoupon(UpdateDiscountCommand command) 
        {
            await _mediator.Send(command);


            return Ok();


        }
        //#region Add Crud System for discount
        /// <summary>
        /// افزودن کتگوری جدید
        /// </summary>
        /// <returns></returns>

        //[HttpPost("Add-Discount")]
        //[ProducesResponseType(typeof(bool), 200)]
        //public async Task<IActionResult> InsertData([FromBody] DiscountCommand discountCommand)
        //{
        //    discountCommand.TypeRequst = (int)RequstType.Add;
        //    var res = await _mediator.Send(discountCommand);
        //    return Ok(res);
        //}
        /// <summary>
        /// بروز رسانی کتگوری
        /// </summary>
        /// <returns></returns>
        //[HttpPut("Update-Discount")]
        //public async Task<IActionResult> UpdateData([FromBody] DiscountCommand discountCommand)
        //{
        //    discountCommand.TypeRequst = (int)RequstType.Update;
        //    var res = await _mediator.Send(discountCommand);
        //    return Ok(res);

        //}
        /// <summary>
        /// حذف کتگوری 
        /// </summary>
        /// <returns></returns>
        //[HttpDelete("Delete-Discount")]
        //public async Task<IActionResult> DeleteData([FromBody] DiscountCommand discountCommand)
        //{
        //    discountCommand.TypeRequst = (int)RequstType.Delete;
        //    var res = await _mediator.Send(discountCommand);
        //    return Ok(res);
        //    #endregion
        //}
        [HttpPost("HangFire")]
        public async Task<IActionResult> ScheduleDiscountJob([FromBody] ScheduleDiscountJobCommand command)
        {
            await _mediator.Send(command);
            return Ok("Recurring job scheduled successfully.");
        }
    }
}