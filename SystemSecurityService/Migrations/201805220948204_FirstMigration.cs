namespace SystemSecurityService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Systemms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemmName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ElementRequirements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemmID = c.Int(nullable: false),
                        ElementID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Systemms", t => t.SystemmID, cascadeDelete: true)
                .ForeignKey("dbo.Elements", t => t.ElementID, cascadeDelete: true)
                .Index(t => t.SystemmID)
                .Index(t => t.ElementID);
            
            CreateTable(
                "dbo.Elements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ElementName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ElementStorages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StorageID = c.Int(nullable: false),
                        ElementID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Elements", t => t.ElementID, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageID, cascadeDelete: true)
                .Index(t => t.StorageID)
                .Index(t => t.ElementID);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StorageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                    SystemmID = c.Int(nullable: false),
                        ExecutorID = c.Int(),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Systemms", t => t.SystemmID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Executors", t => t.ExecutorID)
                .Index(t => t.CustomerID)
                .Index(t => t.SystemmID)
                .Index(t => t.ExecutorID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Executors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExecutorFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ExecutorID", "dbo.Executors");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "SystemmID", "dbo.Systemms");
            DropForeignKey("dbo.ElementStorages", "StorageID", "dbo.Storages");
            DropForeignKey("dbo.ElementStorages", "ElementID", "dbo.Elements");
            DropForeignKey("dbo.ElementRequirements", "ElementID", "dbo.Elements");
            DropForeignKey("dbo.ElementRequirements", "SystemmID", "dbo.Systemms");
            DropIndex("dbo.Orders", new[] { "ExecutorID" });
            DropIndex("dbo.Orders", new[] { "SystemmID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.ElementStorages", new[] { "ElementID" });
            DropIndex("dbo.ElementStorages", new[] { "StorageID" });
            DropIndex("dbo.ElementRequirements", new[] { "ElementID" });
            DropIndex("dbo.ElementRequirements", new[] { "SystemmID" });
            DropTable("dbo.Executors");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.Storages");
            DropTable("dbo.ElementStorages");
            DropTable("dbo.Elements");
            DropTable("dbo.ElementRequirements");
            DropTable("dbo.Systemms");
        }
    }
}
