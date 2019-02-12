using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budget.Models
{
    public class BudgetSummary
    {
        public int Id { get; set; }        
        public double TotalSaved { get; set; }
        public double TotalSpent { get; set; }
        public int DaysSavingCount { get; set; }
        public double AverageDailySpent { get; set; }
        public double AverageDailyEarned { get; set; }
        public User User { get; set; }
    }
}