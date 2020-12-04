namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reports", "Salary", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "Salary", c => c.Int(nullable: false));
        }
    }
}
