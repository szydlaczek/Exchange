namespace Exchange.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Unit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CurrencyValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchasePrice = c.Double(nullable: false),
                        SellPrice = c.Double(nullable: false),
                        AveragePrice = c.Double(nullable: false),
                        PublicationDate = c.DateTime(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserWallets",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        AmountPLN = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserWalletCurrencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserWalletId = c.String(maxLength: 128),
                        CurrencyId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.UserWallets", t => t.UserWalletId)
                .Index(t => t.UserWalletId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.SystemWallets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountPLN = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemWalletCurrencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ammount = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        SystemWalletId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.SystemWallets", t => t.SystemWalletId, cascadeDelete: true)
                .Index(t => t.CurrencyId)
                .Index(t => t.SystemWalletId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Role_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemWalletCurrencies", "SystemWalletId", "dbo.SystemWallets");
            DropForeignKey("dbo.SystemWalletCurrencies", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.UserWallets", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserWalletCurrencies", "UserWalletId", "dbo.UserWallets");
            DropForeignKey("dbo.UserWalletCurrencies", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CurrencyValues", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.SystemWalletCurrencies", new[] { "SystemWalletId" });
            DropIndex("dbo.SystemWalletCurrencies", new[] { "CurrencyId" });
            DropIndex("dbo.UserWalletCurrencies", new[] { "CurrencyId" });
            DropIndex("dbo.UserWalletCurrencies", new[] { "UserWalletId" });
            DropIndex("dbo.UserWallets", new[] { "UserId" });
            DropIndex("dbo.CurrencyValues", new[] { "CurrencyId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.SystemWalletCurrencies");
            DropTable("dbo.SystemWallets");
            DropTable("dbo.UserWalletCurrencies");
            DropTable("dbo.UserWallets");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.CurrencyValues");
            DropTable("dbo.Currencies");
        }
    }
}
