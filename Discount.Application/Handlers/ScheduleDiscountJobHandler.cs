using Discount.Application.Commands;
using Discount.Infra.Persistence.HangFire;
using Hangfire;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Handlers
{
    public class ScheduleDiscountJobHandler : IRequestHandler<ScheduleDiscountJobCommand>
    {
        private readonly IRecurringJobManager _recurringJobManager;

        public ScheduleDiscountJobHandler(IRecurringJobManager recurringJobManager)
        {
            _recurringJobManager = recurringJobManager;
        }

        public Task Handle(ScheduleDiscountJobCommand request, CancellationToken cancellationToken)
        {
            _recurringJobManager.AddOrUpdate<DatabaseChecker>(
             "Update",
             x => x.CheckAndUpdateDiscounts(),
             Cron.MinuteInterval(request.IntervalInHours));

            return Task.CompletedTask;
        }
    }
}
