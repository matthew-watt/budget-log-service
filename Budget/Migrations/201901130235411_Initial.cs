namespace Budget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BudgetDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Earned = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Spent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Logged = c.Boolean(nullable: false),
                        LoggedTime = c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Date, unique: true, name: "BudgetDateIndex");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BudgetDays", "BudgetDateIndex");
            DropTable("dbo.BudgetDays");
        }
    }
}
