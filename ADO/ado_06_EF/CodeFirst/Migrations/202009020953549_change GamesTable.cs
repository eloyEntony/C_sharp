namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeGamesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "DeveloperID", "dbo.Developers");
            DropForeignKey("dbo.Games", "GenreID", "dbo.Genres");
            DropIndex("dbo.Games", new[] { "GenreID" });
            DropIndex("dbo.Games", new[] { "DeveloperID" });
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Games", "Price", c => c.Double());
            AlterColumn("dbo.Games", "Description", c => c.String(maxLength: 300));
            AlterColumn("dbo.Games", "GenreID", c => c.Int());
            AlterColumn("dbo.Games", "DeveloperID", c => c.Int());
            CreateIndex("dbo.Games", "GenreID");
            CreateIndex("dbo.Games", "DeveloperID");
            AddForeignKey("dbo.Games", "DeveloperID", "dbo.Developers", "ID");
            AddForeignKey("dbo.Games", "GenreID", "dbo.Genres", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.Games", "DeveloperID", "dbo.Developers");
            DropIndex("dbo.Games", new[] { "DeveloperID" });
            DropIndex("dbo.Games", new[] { "GenreID" });
            AlterColumn("dbo.Games", "DeveloperID", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "GenreID", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "Description", c => c.String());
            AlterColumn("dbo.Games", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "Name", c => c.String());
            CreateIndex("dbo.Games", "DeveloperID");
            CreateIndex("dbo.Games", "GenreID");
            AddForeignKey("dbo.Games", "GenreID", "dbo.Genres", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Games", "DeveloperID", "dbo.Developers", "ID", cascadeDelete: true);
        }
    }
}
