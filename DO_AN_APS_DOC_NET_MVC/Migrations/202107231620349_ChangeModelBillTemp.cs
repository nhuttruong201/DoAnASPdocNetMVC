namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModelBillTemp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bill_Temp", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Bill_Temp", "Name", c => c.String());
            AddColumn("dbo.Bill_Temp", "Color", c => c.String());
            AddColumn("dbo.Bill_Temp", "Size", c => c.String());
            AddColumn("dbo.Bill_Temp", "Image_Front", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bill_Temp", "Image_Front");
            DropColumn("dbo.Bill_Temp", "Size");
            DropColumn("dbo.Bill_Temp", "Color");
            DropColumn("dbo.Bill_Temp", "Name");
            DropColumn("dbo.Bill_Temp", "Price");
        }
    }
}
