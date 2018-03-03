using System;

namespace LiveTddTotalAmount
{
    public class Budget
    {
        public int Amount { get; set; }
        public string YearMonth { get; set; }

        public DateTime FirstDay
        {
            get
            {
                return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);
            }
        }

        public DateTime LastDay
        {
            get
            {
                return DateTime.ParseExact(YearMonth + TotalDays, "yyyyMMdd", null);
            }
        }

        public int TotalDays
        {
            get
            {
                return DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
            }
        }

        public int DailyAmount()
        {
            var dailyAmount = Amount / TotalDays;
            return dailyAmount;
        }

        public decimal EffectiveAmount(Period period)
        {
            return period.OverlappingDays(new Period(FirstDay, LastDay)) * DailyAmount();
        }
    }
}