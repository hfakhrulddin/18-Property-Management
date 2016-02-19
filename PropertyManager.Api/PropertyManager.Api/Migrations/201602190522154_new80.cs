namespace PropertyManager.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new80 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        Address4 = c.String(),
                        Address5 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostCode = c.String(),
                        International = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        PropertyId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AddressId = c.Int(nullable: false),
                        PropertyName = c.String(),
                        SquareFeet = c.Int(),
                        NumberOfBedrooms = c.Int(),
                        NumberOfBathrooms = c.Single(nullable: false),
                        NumberOfVehicales = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Leases",
                c => new
                    {
                        LeaseId = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        RentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RentFrequencies = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeaseId)
                .ForeignKey("dbo.Tenants", t => t.TenantId, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.TenantId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        TenantId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AddressId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Telephone = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.TenantId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.UserId)
                .Index(t => t.AddressId);
            
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
                "dbo.WorkOrders",
                c => new
                    {
                        WorkOrderId = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        TenantId = c.Int(),
                        Description = c.String(),
                        OpenedDate = c.DateTime(nullable: false),
                        ClosedDate = c.DateTime(nullable: false),
                        Priorities = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkOrderId)
                .ForeignKey("dbo.Tenants", t => t.TenantId)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId)
                .Index(t => t.TenantId);
            
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
            DropForeignKey("dbo.Tenants", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Properties", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.WorkOrders", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Leases", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.WorkOrders", "TenantId", "dbo.Tenants");
            DropForeignKey("dbo.Tenants", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Properties", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Leases", "TenantId", "dbo.Tenants");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.WorkOrders", new[] { "TenantId" });
            DropIndex("dbo.WorkOrders", new[] { "PropertyId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Tenants", new[] { "AddressId" });
            DropIndex("dbo.Tenants", new[] { "UserId" });
            DropIndex("dbo.Leases", new[] { "PropertyId" });
            DropIndex("dbo.Leases", new[] { "TenantId" });
            DropIndex("dbo.Properties", new[] { "AddressId" });
            DropIndex("dbo.Properties", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.WorkOrders");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tenants");
            DropTable("dbo.Leases");
            DropTable("dbo.Properties");
            DropTable("dbo.Addresses");
        }
    }
}
