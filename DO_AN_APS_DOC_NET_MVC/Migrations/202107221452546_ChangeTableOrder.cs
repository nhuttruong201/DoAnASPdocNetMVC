namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableOrder : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "Date", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Orders", new[] { "Id_Customer", "Id_Product", "Date" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "Date", c => c.String());
            AddPrimaryKey("dbo.Orders", new[] { "Id_Customer", "Id_Product" });
        }
    }
}
