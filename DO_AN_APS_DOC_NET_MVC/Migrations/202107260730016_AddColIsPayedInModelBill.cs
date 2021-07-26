namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColIsPayedInModelBill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "IsPayed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "IsPayed");
        }
    }
}
