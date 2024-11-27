using AutoMapper;
using Discount.Application.DTOs;
using Discount.Application.Query;
using Discount.Domain.IRepository.IQuery;
using Discount.Domain.IRepository.IQuery.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Handlers.Query
{
    public class GetDiscountQueryHandler : IRequestHandler<GetDiscountByIdQuery, CouponDto>
    {
        private readonly IDiscountQueryRepository _queryRepository;
        private readonly IMapper _mapper;

        public GetDiscountQueryHandler(IDiscountQueryRepository queryRepository, IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public async Task<CouponDto> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _queryRepository.GetByIdAsync(request.CouponId);
            if (coupon == null)
                throw new Exception("Coupon not found.");

            
            return  _mapper.Map<CouponDto>(coupon);
        }
    }
}
