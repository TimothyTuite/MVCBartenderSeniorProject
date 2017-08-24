namespace MVCBartender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        costOfOrder = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.barProducts",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        type = c.String(nullable: false),
                        name = c.String(nullable: false),
                        price = c.Single(nullable: false),
                        order_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.orders", t => t.order_id)
                .Index(t => t.order_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.barProducts", "order_id", "dbo.orders");
            DropIndex("dbo.barProducts", new[] { "order_id" });
            DropTable("dbo.barProducts");
            DropTable("dbo.orders");
        }
    }
}
