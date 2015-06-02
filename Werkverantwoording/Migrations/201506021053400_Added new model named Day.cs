namespace Werkverantwoording.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddednewmodelnamedDay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        Submitted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Progresses", "taskID", c => c.Int(nullable: false));
            AddColumn("dbo.Progresses", "dayID", c => c.Int(nullable: false));
            DropColumn("dbo.Progresses", "UserID");
            DropColumn("dbo.Progresses", "Completed");
            DropColumn("dbo.Progresses", "Submitted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Progresses", "Submitted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Progresses", "Completed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Progresses", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Progresses", "dayID");
            DropColumn("dbo.Progresses", "taskID");
            DropTable("dbo.Days");
        }
    }
}
