namespace FestivalMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_AdminUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Account = c.String(),
                        Password = c.String(),
                        MaNhanSu = c.Int(nullable: false),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Avatar = c.String(),
                        IdPhongBan = c.Int(nullable: false),
                        SessionToken = c.String(),
                        Salt = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ISsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Icon = c.String(),
                        Description = c.String(),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        Alias = c.String(),
                        Order = c.Int(nullable: false),
                        Slug = c.String(),
                        Views = c.Int(nullable: false),
                        Likes = c.Int(nullable: false),
                        Star = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Detail = c.String(),
                        Image = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Code = c.String(),
                        Alias = c.String(),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        Views = c.Int(nullable: false),
                        Likes = c.Int(nullable: false),
                        Star = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        Slug = c.String(),
                        Order = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.tb_Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Website = c.String(maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 4000),
                        Message = c.String(),
                        IsRead = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Detail = c.String(),
                        Image = c.String(),
                        Code = c.String(),
                        Alias = c.String(),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        Views = c.Int(nullable: false),
                        Likes = c.Int(nullable: false),
                        Star = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        Slug = c.String(),
                        Order = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_EventsImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventsId = c.Int(nullable: false),
                        Image = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Events", t => t.EventsId, cascadeDelete: true)
                .Index(t => t.EventsId);
            
            CreateTable(
                "dbo.tb_EventsContactCustomer",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Phone = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.tb_Introduction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Detail = c.String(),
                        Code = c.String(),
                        Slug = c.String(),
                        Order = c.Int(nullable: false),
                        Image = c.String(),
                        Alias = c.String(),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Alias = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        Detail = c.String(),
                        Image = c.String(),
                        ProductCode = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceSale = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        IsHot = c.Boolean(nullable: false),
                        IsHome = c.Boolean(nullable: false),
                        IsSale = c.Boolean(nullable: false),
                        Views = c.Int(nullable: false),
                        Slug = c.String(),
                        Order = c.Int(nullable: false),
                        Likes = c.Int(nullable: false),
                        Star = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsFeature = c.Boolean(nullable: false),
                        SeoTitle = c.String(maxLength: 250),
                        SeoDescription = c.String(maxLength: 500),
                        SeoKeywords = c.String(maxLength: 250),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_ProductImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Image = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.tb_Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Detail = c.String(),
                        Image = c.String(),
                        Code = c.String(),
                        Alias = c.String(),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        Slug = c.String(),
                        Order = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        Likes = c.Int(nullable: false),
                        Star = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Slides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Sub_Title = c.String(),
                        Urls = c.String(),
                        Image = c.String(),
                        Notes = c.String(),
                        Slug = c.String(),
                        Order = c.Int(nullable: false),
                        Code = c.String(),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_SystemSetting",
                c => new
                    {
                        SettingKey = c.String(nullable: false, maxLength: 50),
                        SettingValue = c.String(maxLength: 4000),
                        SettingDescription = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.SettingKey);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_EventsImage", "EventsId", "dbo.tb_Events");
            DropForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.tb_ProductImage", new[] { "ProductId" });
            DropIndex("dbo.tb_EventsImage", new[] { "EventsId" });
            DropIndex("dbo.tb_News", new[] { "CategoryId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.tb_SystemSetting");
            DropTable("dbo.tb_Slides");
            DropTable("dbo.tb_Sales");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.tb_ProductImage");
            DropTable("dbo.tb_Product");
            DropTable("dbo.tb_Introduction");
            DropTable("dbo.tb_EventsContactCustomer");
            DropTable("dbo.tb_EventsImage");
            DropTable("dbo.tb_Events");
            DropTable("dbo.tb_Contact");
            DropTable("dbo.tb_News");
            DropTable("dbo.tb_Category");
            DropTable("dbo.tb_AdminUser");
        }
    }
}
