namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Image = c.String(),
                        Description = c.String(),
                        Developer_ID = c.Int(),
                        Genre_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Developers", t => t.Developer_ID)
                .ForeignKey("dbo.Genres", t => t.Genre_ID)
                .Index(t => t.Developer_ID)
                .Index(t => t.Genre_ID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Genre_ID", "dbo.Genres");
            DropForeignKey("dbo.Games", "Developer_ID", "dbo.Developers");
            DropIndex("dbo.Games", new[] { "Genre_ID" });
            DropIndex("dbo.Games", new[] { "Developer_ID" });
            DropTable("dbo.Genres");
            DropTable("dbo.Games");
            DropTable("dbo.Developers");
        }
    }
}
