namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "Developer_ID", "dbo.Developers");
            DropForeignKey("dbo.Games", "Genre_ID", "dbo.Genres");
            DropIndex("dbo.Games", new[] { "Developer_ID" });
            DropIndex("dbo.Games", new[] { "Genre_ID" });
            RenameColumn(table: "dbo.Games", name: "Developer_ID", newName: "DeveloperID");
            RenameColumn(table: "dbo.Games", name: "Genre_ID", newName: "GenreID");
            AlterColumn("dbo.Games", "DeveloperID", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "GenreID", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "GenreID");
            CreateIndex("dbo.Games", "DeveloperID");
            AddForeignKey("dbo.Games", "DeveloperID", "dbo.Developers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Games", "GenreID", "dbo.Genres", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.Games", "DeveloperID", "dbo.Developers");
            DropIndex("dbo.Games", new[] { "DeveloperID" });
            DropIndex("dbo.Games", new[] { "GenreID" });
            AlterColumn("dbo.Games", "GenreID", c => c.Int());
            AlterColumn("dbo.Games", "DeveloperID", c => c.Int());
            RenameColumn(table: "dbo.Games", name: "GenreID", newName: "Genre_ID");
            RenameColumn(table: "dbo.Games", name: "DeveloperID", newName: "Developer_ID");
            CreateIndex("dbo.Games", "Genre_ID");
            CreateIndex("dbo.Games", "Developer_ID");
            AddForeignKey("dbo.Games", "Genre_ID", "dbo.Genres", "ID");
            AddForeignKey("dbo.Games", "Developer_ID", "dbo.Developers", "ID");
        }
    }
}
