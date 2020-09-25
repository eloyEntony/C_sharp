namespace EF_CodeFirst_WPF_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatebase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Coment", c => c.String());
            AddColumn("dbo.Products", "IsLegal", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "OverDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "Email", c => c.String());
            AddColumn("dbo.Manufactures", "Product_ID", c => c.Int());
            CreateIndex("dbo.Manufactures", "Product_ID");
            AddForeignKey("dbo.Manufactures", "Product_ID", "dbo.Products", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Manufactures", "Product_ID", "dbo.Products");
            DropIndex("dbo.Manufactures", new[] { "Product_ID" });
            DropColumn("dbo.Manufactures", "Product_ID");
            DropColumn("dbo.Clients", "Email");
            DropColumn("dbo.Products", "OverDate");
            DropColumn("dbo.Products", "IsLegal");
            DropColumn("dbo.Addresses", "Coment");
        }
    }
}
