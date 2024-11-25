using Discount.Application.Commands;
using Discount.Application.Services;
using Discount.Domain.IRepository.ICommand;
using Discount.Domain.IRepository.IQuery.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Handlers.Command
{
    public class ApplyDiscountCommandHandler : IRequestHandler<ApplyDiscountCommand, decimal>
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IQueryRepository _queryRepository;
        private readonly CalculateService _calculateService;



        public ApplyDiscountCommandHandler(ICommandRepository commandRepository, IQueryRepository queryRepository, CalculateService calculateService)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _calculateService = calculateService;
        }

        public async Task<decimal> Handle(ApplyDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _queryRepository.GetByIdAsync(request.CouponId);
            if (coupon == null || !coupon.IsActive)
            {
                throw new Exception("Coupon is invalid or expired.");
            }
               
     
            return request.OriginalPrice -(_calculateService.CalculateDiscount(request.OriginalPrice,coupon));
        }
    }
}
