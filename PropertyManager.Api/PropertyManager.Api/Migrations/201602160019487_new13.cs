namespace PropertyManager.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "PropertyManagerUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Leases", "PropertyManagerUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkOrders", "PropertyManagerUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Addresses", new[] { "PropertyManagerUser_Id" });
            DropIndex("dbo.Leases", new[] { "PropertyManagerUser_Id" });
            DropIndex("dbo.WorkOrders", new[] { "PropertyManagerUser_Id" });
            DropColumn("dbo.Addresses", "PropertyManagerUser_Id");
            DropColumn("dbo.Leases", "PropertyManagerUser_Id");
            DropColumn("dbo.WorkOrders", "PropertyManagerUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkOrders", "PropertyManagerUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Leases", "PropertyManagerUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Addresses", "PropertyManagerUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.WorkOrders", "PropertyManagerUser_Id");
            CreateIndex("dbo.Leases", "PropertyManagerUser_Id");
            CreateIndex("dbo.Addresses", "PropertyManagerUser_Id");
            AddForeignKey("dbo.WorkOrders", "PropertyManagerUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Leases", "PropertyManagerUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Addresses", "PropertyManagerUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
