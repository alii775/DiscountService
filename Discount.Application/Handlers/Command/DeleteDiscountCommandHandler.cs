
using Discount.Application.Command;
using Discount.Domain.IRepository.ICommand;
using MediatR;

public class DeleteCouponCommandHandler : IRequestHandler<DeleteDiscountCommand>
{
    private readonly ICommandRepository _commandrepository;

    public DeleteCouponCommandHandler(ICommandRepository commandrepository)
    {
       _commandrepository = commandrepository;
    }

   
    public async Task Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
    {
        await _commandrepository.DeleteAsync(request.CouponId);
        return;
    }
}