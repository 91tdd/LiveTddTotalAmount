using System;
using System.Linq;

namespace LiveTddTotalAmount
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public decimal OverlappingDays(Period period)
        {
            if (StartDate > period.EndDate)
            {
                return 0;
            }
            if (EndDate < period.StartDate)
            {
                return 0;
            }
            var effectiveEndDate = EndDate > period.EndDate
                ? period.EndDate
                : EndDate;

            var effectiveStartDate = StartDate < period.StartDate
                ? period.StartDate
                : StartDate;

            var days = (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
            return days;
        }
    }

    public class Accouting
    {
        private readonly IRepository<Budget> _repository;

        public Accouting(IRepository<Budget> repository)
        {
            _repository = repository;
        }

        public decimal TotalAmount(DateTime startDate, DateTime endDate)
        {
            var period = new Period(startDate, endDate);
            var budgets = _repository.GetAll();
            if (budgets.Any())
            {
                var budget = budgets[0];
                return period.OverlappingDays(new Period(budget.FirstDay, budget.LastDay));
            }
            return 0;
        }
    }
}