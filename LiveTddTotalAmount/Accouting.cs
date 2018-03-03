using System;

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
            var totalAmount = 0m;
            foreach (var budget in budgets)
            {
                totalAmount += budget.EffectiveAmount(period);
            }
            return totalAmount;
        }
    }
}