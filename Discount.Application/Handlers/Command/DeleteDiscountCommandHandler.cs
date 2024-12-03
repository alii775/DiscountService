
using AutoMapper;
using Discount.Application.Commands;
using Discount.Application.DTOs;
using Discount.Domain.Entities;
using Discount.Domain.IRepository.ICommand;
using Discount.Domain.IRepository.IQuery;
using Discount.Domain.IRepository.IQuery.Base;
using Discount.Infra.Persistence.Repository.Command;
using Discount.Infra.Persistence.Repository.Query;
using MediatR;
namespace Discount.Application.Handlers.Command
{
    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand>
    {
        private readonly IDiscountCommandRepository _commandrepository;
        private readonly IMapper _mapper;




        public DeleteDiscountCommandHandler(IDiscountCommandRepository commandrepository, IMapper mapper)
        {
            _commandrepository = commandrepository;
            _mapper = mapper;
        }


        public async Task Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
             var res= _mapper.Map<Coupon>(request);
            if (res.Id==request.CouponId) 
            {
                await _commandrepository.DeleteAsync(res);
            };
          
        }

    }
}
