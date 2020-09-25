namespace EF_CodeFirst_WPF_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Country = c.String(maxLength: 100),
                        City = c.String(maxLength: 100),
                        Street = c.String(maxLength: 100),
                        Builder = c.Int(),
                        Manufacture_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Manufactures", t => t.Manufacture_ID)
                .Index(t => t.Manufacture_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        AddressID = c.Int(),
                        Client_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.AddressID)
                .ForeignKey("dbo.Clients", t => t.Client_ID)
                .Index(t => t.AddressID)
                .Index(t => t.Client_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(maxLength: 300),
                        Category_ID = c.Int(),
                        Category_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID1)
                .Index(t => t.Category_ID1);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Manufactures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Product_ID = c.Int(nullable: false),
                        Order_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ID, t.Order_ID })
                .ForeignKey("dbo.Products", t => t.Product_ID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_ID, cascadeDelete: true)
                .Index(t => t.Product_ID)
                .Index(t => t.Order_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Manufacture_ID", "dbo.Manufactures");
            DropForeignKey("dbo.Orders", "Client_ID", "dbo.Clients");
            DropForeignKey("dbo.Products", "Category_ID1", "dbo.Categories");
            DropForeignKey("dbo.Orders", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.ProductOrders", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "Product_ID", "dbo.Products");
            DropIndex("dbo.ProductOrders", new[] { "Order_ID" });
            DropIndex("dbo.ProductOrders", new[] { "Product_ID" });
            DropIndex("dbo.Products", new[] { "Category_ID1" });
            DropIndex("dbo.Orders", new[] { "Client_ID" });
            DropIndex("dbo.Orders", new[] { "AddressID" });
            DropIndex("dbo.Addresses", new[] { "Manufacture_ID" });
            DropTable("dbo.ProductOrders");
            DropTable("dbo.Manufactures");
            DropTable("dbo.Clients");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Addresses");
        }
    }
}
