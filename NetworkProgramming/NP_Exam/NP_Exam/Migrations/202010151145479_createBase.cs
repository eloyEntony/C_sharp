namespace NP_Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstUserId = c.Int(),
                        SecondUserId = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.FirstUserId)
                .ForeignKey("dbo.Users", t => t.SecondUserId)
                .Index(t => t.FirstUserId)
                .Index(t => t.SecondUserId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        ContactId = c.Int(),
                        ChatId = c.Int(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.ChatId)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .Index(t => t.ContactId)
                .Index(t => t.ChatId)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chats", "SecondUserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "ChatId", "dbo.Chats");
            DropForeignKey("dbo.Chats", "FirstUserId", "dbo.Users");
            DropForeignKey("dbo.Users", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Chats", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "ChatId", "dbo.Chats");
            DropIndex("dbo.Messages", new[] { "ChatId" });
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Contact_Id" });
            DropIndex("dbo.Users", new[] { "ChatId" });
            DropIndex("dbo.Users", new[] { "ContactId" });
            DropIndex("dbo.Chats", new[] { "User_Id" });
            DropIndex("dbo.Chats", new[] { "SecondUserId" });
            DropIndex("dbo.Chats", new[] { "FirstUserId" });
            DropTable("dbo.Messages");
            DropTable("dbo.Contacts");
            DropTable("dbo.Users");
            DropTable("dbo.Chats");
        }
    }
}
