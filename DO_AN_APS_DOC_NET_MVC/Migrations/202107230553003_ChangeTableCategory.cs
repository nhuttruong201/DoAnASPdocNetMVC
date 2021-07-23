namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Image_Cover", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Image_Cover");
        }
    }
}
