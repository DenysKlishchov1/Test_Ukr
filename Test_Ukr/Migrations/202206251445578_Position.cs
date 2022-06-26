namespace Test_Ukr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Position : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Positions", new[] { "DepartmentId" });
            DropTable("dbo.Positions");
        }
    }
}
