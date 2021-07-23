namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDB1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bill_Temp",
                c => new
                    {
                        Id_Bill_Temp = c.Int(nullable: false, identity: true),
                        Id_Product = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Bill_Temp);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bill_Temp");
        }
    }
}
