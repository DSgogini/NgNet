namespace ConsServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblchange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EmployeeEntities", newName: "Employee");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Employee", newName: "EmployeeEntities");
        }
    }
}
