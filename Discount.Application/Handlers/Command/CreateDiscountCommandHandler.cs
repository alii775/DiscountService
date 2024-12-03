
using AutoMapper;
using Discount.Application.Commands;
using Discount.Application.DTOs;
using Discount.Application.Services;
using Discount.Domain.Entities;
using Discount.Domain.IRepository.ICommand;
using MediatR;

namespace Discount.Application.Handlers.Command
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand>
    {
        private readonly IDiscountCommandRepository _commandRepository;
        private readonly IMapper _mapper;

        public CreateDiscountCommandHandler(IDiscountCommandRepository commandRepository, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _mapper = mapper;
        }

      
        public async Task Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {

            var coupon = _mapper.Map<Coupon>(request);
           
            await _commandRepository.AddAsync(coupon);

        }
    }
    }





