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
            return 0;
        }
    }
}