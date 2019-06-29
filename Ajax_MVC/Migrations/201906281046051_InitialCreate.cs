namespace Ajax_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department_2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DName = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee_2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EName = c.String(),
                        Salary = c.Int(nullable: false),
                        Department_2Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department_2", t => t.Department_2Id, cascadeDelete: true)
                .Index(t => t.Department_2Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee_2", "Department_2Id", "dbo.Department_2");
            DropIndex("dbo.Employee_2", new[] { "Department_2Id" });
            DropTable("dbo.Employee_2");
            DropTable("dbo.Department_2");
        }
    }
}
