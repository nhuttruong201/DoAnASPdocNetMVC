namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableOrder1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Orders");
            AddColumn("dbo.Orders", "Id_Order", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Orders", "Id_Customer", c => c.String());
            AlterColumn("dbo.Orders", "Date", c => c.String());
            AddPrimaryKey("dbo.Orders", "Id_Order");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "Date", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Orders", "Id_Customer", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Orders", "Id_Order");
            AddPrimaryKey("dbo.Orders", new[] { "Id_Customer", "Id_Product", "Date" });
        }
    }
}
