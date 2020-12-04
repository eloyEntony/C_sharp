namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "DepartmentId");
            RenameColumn(table: "dbo.Employees", name: "Departament_Id", newName: "DepartmentId");
            RenameIndex(table: "dbo.Employees", name: "IX_Departament_Id", newName: "IX_DepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Employees", name: "IX_DepartmentId", newName: "IX_Departament_Id");
            RenameColumn(table: "dbo.Employees", name: "DepartmentId", newName: "Departament_Id");
            AddColumn("dbo.Employees", "DepartmentId", c => c.Int());
        }
    }
}
