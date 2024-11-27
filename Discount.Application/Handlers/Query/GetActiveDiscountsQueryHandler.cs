using AutoMapper;
using Discount.Application.DTOs;
using Discount.Application.Query;
using Discount.Domain.Entities;
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

    public class GetActiveDiscountsQueryHandler : IRequestHandler<GetActiveDiscountsQuery, List<CouponDto>>
    {
        private readonly IDiscountQueryRepository _queryRepository;
        private readonly IMapper _mapper;

        public GetActiveDiscountsQueryHandler(IDiscountQueryRepository queryRepository, IMapper mapper)
        {
          _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public async Task<List<CouponDto>> Handle(GetActiveDiscountsQuery request, CancellationToken cancellationToken)
        {
            var activeCoupons = await _queryRepository.GetActiveDiscountAsync();

           
            return _mapper.Map<List<CouponDto>>(activeCoupons);
        }
    }
}
