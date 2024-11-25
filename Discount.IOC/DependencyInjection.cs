using Discount.Application.Handlers.Command;
using Discount.Application.Handlers.Query;
using Discount.Application.Helper.MappingProfile;
using Discount.Application.Services;
using Discount.Domain.IRepository.ICommand;
using Discount.Domain.IRepository.IQuery.Base;
using Discount.Infra.Persistence.Data;
using Discount.Infra.Persistence.Repository.Command.Base;
using Discount.Infra.Persistence.Repository.Query;
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped(typeof(ICommandRepository), typeof(CommandRepository));
            services.AddScoped(typeof(IQueryRepository), typeof(QueryRepository));
            services.AddScoped<DiscountCommandDbContext>();
            services.AddTransient<DiscountQueryDbContext>();
            services.AddScoped<CalculateService>();

        }
    }
}
