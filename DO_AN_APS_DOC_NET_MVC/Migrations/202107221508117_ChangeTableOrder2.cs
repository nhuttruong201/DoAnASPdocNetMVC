namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableOrder2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PhoneNumber");
        }
    }
}
