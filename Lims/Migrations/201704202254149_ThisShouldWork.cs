namespace Lims.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThisShouldWork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        AssignmentID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TotalSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        Employee_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Employee", t => t.Employee_EmployeeID)
                .Index(t => t.Employee_EmployeeID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PurchaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Quantity = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        UPC = c.Long(nullable: false),
                        SectionID = c.String(),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Inventory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Purchase", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Assignment", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "Employee_EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Assignment", "DepartmentID", "dbo.Department");
            DropIndex("dbo.Purchase", new[] { "CustomerID" });
            DropIndex("dbo.Purchase", new[] { "ProductID" });
            DropIndex("dbo.Employee", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.Assignment", new[] { "DepartmentID" });
            DropIndex("dbo.Assignment", new[] { "EmployeeID" });
            DropTable("dbo.Product");
            DropTable("dbo.Purchase");
            DropTable("dbo.Customer");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            DropTable("dbo.Assignment");
        }
    }
}
