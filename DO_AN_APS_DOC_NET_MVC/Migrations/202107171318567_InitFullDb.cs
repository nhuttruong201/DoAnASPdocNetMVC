namespace DO_AN_APS_DOC_NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitFullDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bill_Detail",
                c => new
                    {
                        Id_Bill = c.Int(nullable: false),
                        Id_Product = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id_Bill, t.Id_Product })
                .ForeignKey("dbo.Bills", t => t.Id_Bill, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Id_Product, cascadeDelete: true)
                .Index(t => t.Id_Bill)
                .Index(t => t.Id_Product);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id_Bill = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Id_Customer = c.String(),
                        Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id_Bill)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id_Product = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Color = c.String(),
                        Size = c.String(),
                        Describe = c.String(),
                        Price = c.Double(nullable: false),
                        Num = c.Int(nullable: false),
                        Id_Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Product)
                .ForeignKey("dbo.Categories", t => t.Id_Category, cascadeDelete: true)
                .Index(t => t.Id_Category);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id_Customer = c.String(nullable: false, maxLength: 128),
                        Id_Product = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Id_Customer, t.Id_Product })
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .ForeignKey("dbo.Products", t => t.Id_Product, cascadeDelete: true)
                .Index(t => t.Id_Product)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id_Category = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id_Category);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id_Customer = c.String(nullable: false, maxLength: 128),
                        Id_Product = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        Date = c.String(),
                        Message = c.String(),
                        Address = c.String(),
                        Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Id_Customer, t.Id_Product })
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .ForeignKey("dbo.Products", t => t.Id_Product, cascadeDelete: true)
                .Index(t => t.Id_Product)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Orders", "Id_Product", "dbo.Products");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "Id_Category", "dbo.Categories");
            DropForeignKey("dbo.Carts", "Id_Product", "dbo.Products");
            DropForeignKey("dbo.Carts", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bill_Detail", "Id_Product", "dbo.Products");
            DropForeignKey("dbo.Bills", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bill_Detail", "Id_Bill", "dbo.Bills");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Orders", new[] { "Id_Product" });
            DropIndex("dbo.Carts", new[] { "Customer_Id" });
            DropIndex("dbo.Carts", new[] { "Id_Product" });
            DropIndex("dbo.Products", new[] { "Id_Category" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Bills", new[] { "Customer_Id" });
            DropIndex("dbo.Bill_Detail", new[] { "Id_Product" });
            DropIndex("dbo.Bill_Detail", new[] { "Id_Bill" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Orders");
            DropTable("dbo.Categories");
            DropTable("dbo.Carts");
            DropTable("dbo.Products");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Bills");
            DropTable("dbo.Bill_Detail");
        }
    }
}
