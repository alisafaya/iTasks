namespace iTasksProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.iTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Priority = c.Int(nullable: false),
                        Complete = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AspNetUsers", "ProfilePhoto", c => c.Binary());
            AddColumn("dbo.AspNetUsers", "CoverPhoto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.iTasks", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.iTasks", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "CoverPhoto");
            DropColumn("dbo.AspNetUsers", "ProfilePhoto");
            DropTable("dbo.iTasks");
        }
    }
}
