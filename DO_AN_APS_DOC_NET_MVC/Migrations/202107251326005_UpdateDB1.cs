namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Image_Front", c => c.String());
            AlterColumn("dbo.Products", "Image_Back", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Image_Back", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Image_Front", c => c.String(nullable: false));
        }
    }
}
