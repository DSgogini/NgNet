namespace ConsServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullabledatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Employee", "DateUpdated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "DateUpdated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employee", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
