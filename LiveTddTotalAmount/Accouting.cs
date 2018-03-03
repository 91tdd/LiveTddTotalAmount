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
            return _repository.GetAll().Sum(b => b.EffectiveAmount(period));
        }
    }
}