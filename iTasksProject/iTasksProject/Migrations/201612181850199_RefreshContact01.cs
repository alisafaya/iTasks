namespace iTasksProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshContact01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactMessageModels", "subject", c => c.String());
            AlterColumn("dbo.ContactMessageModels", "message", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactMessageModels", "message", c => c.String(maxLength: 64));
            AlterColumn("dbo.ContactMessageModels", "subject", c => c.String(maxLength: 64));
        }
    }
}
