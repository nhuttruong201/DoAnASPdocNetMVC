namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateFromStringToDateTime1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bills", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bills", "Date", c => c.String(nullable: false));
        }
    }
}
