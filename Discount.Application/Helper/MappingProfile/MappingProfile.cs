using AutoMapper;
using Discount.Application.Commands;
using Discount.Application.DTOs;
using Discount.Application.Query;
using Discount.Domain.Entities;
using Discount.Domain.IRepository.ICommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Helper.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Coupon, CouponDto>()
                .ForMember(dest => dest.DiscountType, opt => opt.MapFrom(src => src.DiscountType.ToString()))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
       
                
            
            CreateMap<CreateDiscountCommand, Coupon>();
          
        }
    }

}
