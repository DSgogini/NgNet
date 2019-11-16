namespace ConsServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auditinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employee", "DateUpdated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "DateUpdated");
            DropColumn("dbo.Employee", "DateCreated");
        }
    }
}
