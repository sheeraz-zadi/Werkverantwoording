namespace Werkverantwoording.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
            DropColumn("dbo.Users", "Password");
        }
    }
}
