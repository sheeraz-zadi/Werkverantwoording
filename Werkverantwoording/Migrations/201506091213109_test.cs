namespace Werkverantwoording.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "RoleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RoleID", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Role");
        }
    }
}
