namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bills", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Image_Front", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Image_Back", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Color", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Size", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Image_Cover", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Product_Model", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Product_Model", "Describe", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product_Model", "Describe", c => c.String());
            AlterColumn("dbo.Product_Model", "Name", c => c.String());
            AlterColumn("dbo.Orders", "Address", c => c.String());
            AlterColumn("dbo.Orders", "Date", c => c.String());
            AlterColumn("dbo.Orders", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Categories", "Image_Cover", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Products", "Size", c => c.String());
            AlterColumn("dbo.Products", "Color", c => c.String());
            AlterColumn("dbo.Products", "Image_Back", c => c.String());
            AlterColumn("dbo.Products", "Image_Front", c => c.String());
            AlterColumn("dbo.Bills", "Date", c => c.String());
        }
    }
}
