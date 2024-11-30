using AutoMapper;
using Discount.Application.Commands;
using Discount.Domain.IRepository.ICommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discount.Domain.Entities;

namespace Discount.Application.Handlers.Command;

public class CommandDiscountHandler : IRequestHandler<DiscountCommand, bool>
{
    private readonly IDiscountCommandRepository _discountCommand;  
    private IMapper _mapper;
    public CommandDiscountHandler(IDiscountCommandRepository discountCommandRepository, IMapper mapper)
    {
        _discountCommand = discountCommandRepository;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DiscountCommand request, CancellationToken cancellationToken)
    {

        if (request.TypeRequst < 0 || request.TypeRequst > 2)
        {
            throw new ArgumentOutOfRangeException(nameof(request.TypeRequst), "Invalid TypeRequest value. It must be 0, 1, or 2.");
        }


        var category = _mapper.Map<Discount.Domain.Entities.Coupon>(request);


      

        switch (request.TypeRequst)
        {
            case 0: // Add new category
                category.CreatedDate = DateTime.UtcNow;
                await _discountCommand.AddAsync(category);
                break;

            case 1: // Update existing category
                await _discountCommand.UpdateAsync(category);
                break;

            case 2: // Delete category
                await _discountCommand.DeleteAsync(category);
                break;
        }

        return true;
    }
}
