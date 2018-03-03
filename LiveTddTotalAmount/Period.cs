using System;

namespace LiveTddTotalAmount
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException();
            }
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

            var days = Days(EffectiveEndDate(period), EffectiveStartDate(period));
            return days;
        }

        private static int Days(DateTime effectiveEndDate, DateTime effectiveStartDate)
        {
            var days = (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
            return days;
        }

        private DateTime EffectiveStartDate(Period period)
        {
            var effectiveStartDate = StartDate < period.StartDate
                ? period.StartDate
                : StartDate;
            return effectiveStartDate;
        }

        private DateTime EffectiveEndDate(Period period)
        {
            var effectiveEndDate = EndDate > period.EndDate
                ? period.EndDate
                : EndDate;
            return effectiveEndDate;
        }
    }
}