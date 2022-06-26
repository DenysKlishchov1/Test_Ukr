namespace Test_Ukr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldInEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "KPI", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "KPI");
        }
    }
}
