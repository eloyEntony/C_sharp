namespace EF_CodeFirst_WPF_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatebase2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "IsLegal", c => c.Boolean());
            AlterColumn("dbo.Products", "OverDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "OverDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "IsLegal", c => c.Boolean(nullable: false));
        }
    }
}
