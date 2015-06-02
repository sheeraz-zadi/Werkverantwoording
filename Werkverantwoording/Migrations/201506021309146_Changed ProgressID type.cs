namespace Werkverantwoording.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedProgressIDtype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Days", "ProgressID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Days", "ProgressID");
        }
    }
}
