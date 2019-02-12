using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Budget.Models;

namespace Budget.Objects
{
    public class BudgetDaysList
    {
        public ICollection<BudgetDay> BudgetDays;        

        public decimal AverageDailySpending
        {
            get
            {
                return Math.Round(BudgetDays.Average(bd => bd.Spent), 2);
            }
        }

        public decimal TotalSaved
        {
            get
            {
                var totalSpent = BudgetDays.Sum(bd => bd.Spent);
                var totalEarned = BudgetDays.Sum(bd => bd.Earned);
                return totalEarned - totalSpent;
            }
        }

        public decimal TotalSpent
        {
            get
            {
                return BudgetDays.Sum(bd => bd.Spent);
            }
        }

        public decimal TotalEarned
        {
            get
            {
                return BudgetDays.Sum(bd => bd.Earned);
            }
        }

        public int BudgetDaysCount
        {
            get
            {
                return BudgetDays.Count();
            }
        }
    }
}