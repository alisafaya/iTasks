namespace iTasksProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refresh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.iTasks", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.iTasks", "Name", c => c.String());
        }
    }
}
