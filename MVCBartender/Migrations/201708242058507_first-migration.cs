namespace MVCBartender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.barProducts", new[] { "order_id" });
            AddColumn("dbo.orders", "orderdBy", c => c.String(nullable: false));
            CreateIndex("dbo.barProducts", "order_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.barProducts", new[] { "order_Id" });
            DropColumn("dbo.orders", "orderdBy");
            CreateIndex("dbo.barProducts", "order_id");
        }
    }
}
