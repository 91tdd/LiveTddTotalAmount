using System;
using System.Linq;

namespace LiveTddTotalAmount
{
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