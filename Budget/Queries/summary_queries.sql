select SUM(BudgetDays.Income) as 'TotalSaved',
	   SUM(BudgetDays.Expenses) as 'TotalSpent',
	   AVG(BudgetDays.Expenses) as 'AverageDailySpending',
	   COUNT(*) AS 'BudgetDaysCount'
from BudgetDays