namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departaments");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            AddColumn("dbo.Employees", "Departament_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Departament_Id");
            AddForeignKey("dbo.Employees", "Departament_Id", "dbo.Departaments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Departament_Id", "dbo.Departaments");
            DropIndex("dbo.Employees", new[] { "Departament_Id" });
            DropColumn("dbo.Employees", "Departament_Id");
            CreateIndex("dbo.Employees", "DepartmentId");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departaments", "Id");
        }
    }
}
