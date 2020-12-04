namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(maxLength: 10),
                        Street = c.String(maxLength: 10),
                        House = c.String(),
                        Apartment = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        Factory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factories", t => t.Factory_Id)
                .Index(t => t.Factory_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Surname = c.String(maxLength: 10),
                        Photo = c.String(),
                        Phone = c.String(maxLength: 10),
                        DateOfBirths = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 10),
                        Details = c.String(maxLength: 10),
                        AddressId = c.Int(),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Departaments", t => t.DepartmentId)
                .Index(t => t.AddressId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkTime = c.Int(nullable: false),
                        Products = c.Int(),
                        Delay = c.Int(),
                        Overtime = c.Int(),
                        Absenteeism = c.Int(),
                        Year = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                        MonthId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Months", t => t.MonthId)
                .Index(t => t.EmployeeId)
                .Index(t => t.MonthId);
            
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Factories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 100),
                        AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departaments", "Factory_Id", "dbo.Factories");
            DropForeignKey("dbo.Factories", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Reports", "MonthId", "dbo.Months");
            DropForeignKey("dbo.Reports", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departaments");
            DropForeignKey("dbo.Employees", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Factories", new[] { "AddressId" });
            DropIndex("dbo.Reports", new[] { "MonthId" });
            DropIndex("dbo.Reports", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "AddressId" });
            DropIndex("dbo.Departaments", new[] { "Factory_Id" });
            DropTable("dbo.Factories");
            DropTable("dbo.Months");
            DropTable("dbo.Reports");
            DropTable("dbo.Employees");
            DropTable("dbo.Departaments");
            DropTable("dbo.Addresses");
        }
    }
}
