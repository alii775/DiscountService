using AutoMapper;
using Discount.Application.Commands;
using Discount.Domain.Entities;
using Discount.Domain.IRepository.ICommand;
using Discount.Infra.Persistence.Repository.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Handlers.Command
{
    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand>
    {
        private readonly IDiscountCommandRepository _commandrepository;
        private readonly IMapper _mapper;
        public UpdateDiscountCommandHandler(IDiscountCommandRepository commandrepository, IMapper mapper)
        {
            _commandrepository = commandrepository;
            _mapper = mapper;
        }


        public async Task Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = _mapper.Map<Coupon>(request);
            await _commandrepository.UpdateAsync(coupon);

        }
    }
}

