namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColSaleInTableProductModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product_Model", "Sale", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product_Model", "Sale");
        }
    }
}
