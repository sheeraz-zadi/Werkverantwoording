namespace Werkverantwoording.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currentdatabase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Progresses", "userID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Progresses", "userID", c => c.Int(nullable: false));
        }
    }
}
