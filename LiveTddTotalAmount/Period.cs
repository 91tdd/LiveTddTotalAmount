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
            if (HasNoOverlapping(period))
            {
                return 0;
            }

            var days = TotalDays(EffectiveEndDate(period), EffectiveStartDate(period));
            return days;
        }

        private bool HasNoOverlapping(Period period)
        {
            return StartDate > period.EndDate || EndDate < period.StartDate;
        }

        private static int TotalDays(DateTime endDate, DateTime startDate)
        {
            return (endDate.AddDays(1) - startDate).Days;
        }

        private DateTime EffectiveStartDate(Period period)
        {
            return StartDate < period.StartDate
                ? period.StartDate
                : StartDate;
        }

        private DateTime EffectiveEndDate(Period period)
        {
            return EndDate > period.EndDate
                ? period.EndDate
                : EndDate;
        }
    }
}