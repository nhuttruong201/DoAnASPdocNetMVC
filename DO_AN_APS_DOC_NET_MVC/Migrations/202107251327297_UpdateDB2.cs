namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Image_Cover", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Image_Cover", c => c.String(nullable: false));
        }
    }
}
