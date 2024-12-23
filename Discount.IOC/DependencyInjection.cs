﻿using Discount.Application.Commands;
using Discount.Application.Handlers.Command;
using Discount.Application.Handlers.Query;
using Discount.Application.Helper;
using Discount.Application.Services;
using Discount.Domain.IRepository.ICommand;
using Discount.Domain.IRepository.IQuery;
using Discount.Domain.IRepository.IQuery.Base;
using Discount.Infra.Persistence.Data;
using Discount.Infra.Persistence.HangFire;
using Discount.Infra.Persistence.Repository.Command;
using Discount.Infra.Persistence.Repository.Command.Base;
using Discount.Infra.Persistence.Repository.Query;
using Discount.Infra.Persistence.Repository.Query.Base;

using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Discount.IOC
{
    public static class DependencyInjection
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetDiscountQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteDiscountCommandHandler).Assembly));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());           
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped(typeof(IDiscountCommandRepository), typeof(DiscountCommandRepository));
            services.AddScoped(typeof(IDiscountQueryRepository), typeof(DiscountQueryRepository));
            services.AddScoped<DiscountCommandDbContext>();
            services.AddTransient<DiscountQueryDbContext>();
            services.AddScoped<DatabaseChecker>();
          
         
            services.AddHangfireServer();


        }
    }
}
