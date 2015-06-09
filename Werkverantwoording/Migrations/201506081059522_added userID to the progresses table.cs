namespace Werkverantwoording.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduserIDtotheprogressestable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Progresses", "userID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Progresses", "userID");
        }
    }
}
