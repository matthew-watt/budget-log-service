namespace Budget.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.BudgetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BudgetContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //AutomaticMigrationDataLossAllowed = true; this or use -Force with Update-Database

            context.BudgetDays.AddOrUpdate(
                b => b.Date,
                new BudgetDay { Date = new DateTime(2019, 1, 8), Earned = 10, Spent = 8 },
                new BudgetDay { Date = new DateTime(2019, 1, 9), Earned = 23, Spent = 30 },
                new BudgetDay { Date = new DateTime(2019, 1, 10), Earned = 40, Spent = 29 },
                new BudgetDay { Date = new DateTime(2019, 1, 11), Earned = 20, Spent = 10 },
                new BudgetDay { Date = new DateTime(2019, 1, 12), Earned = 3, Spent = 20 },
                new BudgetDay { Date = new DateTime(2019, 1, 13), Earned = 10, Spent = 10 },
                new BudgetDay { Date = new DateTime(2019, 2, 10), Earned = 10, Spent = 10 }
            );
        }
    }
}
