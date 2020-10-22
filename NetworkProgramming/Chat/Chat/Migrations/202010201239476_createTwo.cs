namespace Chat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTwo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersChats", "ChatId", "dbo.Chats");
            DropForeignKey("dbo.UsersChats", "UserId", "dbo.Users");
            DropIndex("dbo.UsersChats", new[] { "UserId" });
            DropIndex("dbo.UsersChats", new[] { "ChatId" });
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageText = c.String(),
                        ChatId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.ChatId)
                .Index(t => t.ChatId);
            
            AlterColumn("dbo.UsersChats", "UserId", c => c.Int());
            AlterColumn("dbo.UsersChats", "ChatId", c => c.Int());
            CreateIndex("dbo.UsersChats", "UserId");
            CreateIndex("dbo.UsersChats", "ChatId");
            AddForeignKey("dbo.UsersChats", "ChatId", "dbo.Chats", "Id");
            AddForeignKey("dbo.UsersChats", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersChats", "UserId", "dbo.Users");
            DropForeignKey("dbo.UsersChats", "ChatId", "dbo.Chats");
            DropForeignKey("dbo.Messages", "ChatId", "dbo.Chats");
            DropIndex("dbo.UsersChats", new[] { "ChatId" });
            DropIndex("dbo.UsersChats", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "ChatId" });
            AlterColumn("dbo.UsersChats", "ChatId", c => c.Int(nullable: false));
            AlterColumn("dbo.UsersChats", "UserId", c => c.Int(nullable: false));
            DropTable("dbo.Messages");
            CreateIndex("dbo.UsersChats", "ChatId");
            CreateIndex("dbo.UsersChats", "UserId");
            AddForeignKey("dbo.UsersChats", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsersChats", "ChatId", "dbo.Chats", "Id", cascadeDelete: true);
        }
    }
}
