namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelOrderDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Id_Product", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Id_Product" });
            CreateTable(
                "dbo.Order_Detail",
                c => new
                    {
                        Id_Order = c.Int(nullable: false),
                        Id_Product = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id_Order, t.Id_Product })
                .ForeignKey("dbo.Orders", t => t.Id_Order, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Id_Product, cascadeDelete: true)
                .Index(t => t.Id_Order)
                .Index(t => t.Id_Product);
            
            DropColumn("dbo.Orders", "Num");
            DropColumn("dbo.Orders", "Id_Product");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Id_Product", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Num", c => c.Int(nullable: false));
            DropForeignKey("dbo.Order_Detail", "Id_Product", "dbo.Products");
            DropForeignKey("dbo.Order_Detail", "Id_Order", "dbo.Orders");
            DropIndex("dbo.Order_Detail", new[] { "Id_Product" });
            DropIndex("dbo.Order_Detail", new[] { "Id_Order" });
            DropTable("dbo.Order_Detail");
            CreateIndex("dbo.Orders", "Id_Product");
            AddForeignKey("dbo.Orders", "Id_Product", "dbo.Products", "Id_Product", cascadeDelete: true);
        }
    }
}
