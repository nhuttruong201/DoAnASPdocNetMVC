namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDB : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carts", "Id_Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Id_Size", c => c.Int(nullable: false));
        }
    }
}
