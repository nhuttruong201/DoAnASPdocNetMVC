namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableOrder3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsCheck", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsCheck");
        }
    }
}
