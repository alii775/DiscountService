
using AutoMapper;
using Discount.Application.Command;
using Discount.Application.Services;
using Discount.Domain.Entities;
using Discount.Domain.IRepository.ICommand;
using MediatR;

public class CreateCouponCommandHandler : IRequestHandler<CreateDiscountCommand, long>
{
    private readonly ICommandRepository _commandRepository;
    private readonly IMapper _mapper;

    public CreateCouponCommandHandler(ICommandRepository commandRepository, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
       
        var coupon = _mapper.Map<Coupon>(request);
        await _commandRepository.AddAsync(coupon);
        return coupon.Id;
    }
}
