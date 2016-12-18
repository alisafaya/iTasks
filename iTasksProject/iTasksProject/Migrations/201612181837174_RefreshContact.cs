namespace iTasksProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshContact : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactMessageModels", "message", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactMessageModels", "message", c => c.String());
        }
    }
}
