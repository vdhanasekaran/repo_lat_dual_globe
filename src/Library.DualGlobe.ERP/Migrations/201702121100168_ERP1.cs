namespace Library.DualGlobe.ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ERP1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterialPurchaseItem", "MaterialPurchaseId", "dbo.MaterialPurchase");
            DropIndex("dbo.MaterialPurchaseItem", new[] { "MaterialPurchaseId" });
            CreateTable(
                "dbo.Expense",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        BillRefNo = c.String(),
                        Supplier = c.String(),
                        ClientId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        PaymentMethod = c.String(),
                        TransRefNo = c.String(),
                        PaymentStatus = c.String(),
                        IncludeGST = c.Boolean(nullable: false),
                        GST = c.Decimal(precision: 18, scale: 2),
                        Description = c.String(),
                        ExpenseCategory = c.String(),
                        MaterialPurchseCategory = c.String(),
                        OperationExpenseCategory = c.String(),
                        OtherExpense = c.String(),
                        ExpenseValue = c.Decimal(precision: 18, scale: 2),
                        ExpenseTotalValue = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(),
                        DocumentUrl = c.String(),
                        Expense_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Expense", t => t.Expense_Id)
                .Index(t => t.Expense_Id);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        FaxNumber = c.String(),
                        ContactPerson = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employee", "HousingAllowance", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Employee", "TransportAllowance", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Employee", "OtherAllowance", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Employee", "HousingDeduction", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Employee", "TransportDeduction", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Employee", "OtherDeduction", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Employee", "FixedDeduction", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Employee", "OADescription", c => c.String());
            AddColumn("dbo.Employee", "ODDescription", c => c.String());
            AddColumn("dbo.Employee", "IsHavingDeduction", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "TierType", c => c.String());
            DropTable("dbo.MaterialPurchaseItem");
            DropTable("dbo.MaterialPurchase");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MaterialPurchase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        BillRefNo = c.String(),
                        SupplierName = c.String(),
                        SupplierAddress = c.String(),
                        ProjectId = c.Int(nullable: false),
                        PaymentMethod = c.String(),
                        TransRefNo = c.String(),
                        PaymentStatus = c.String(),
                        MaterialPurchaseValue = c.Decimal(precision: 18, scale: 2),
                        MaterialPurchaseTotalValue = c.Decimal(precision: 18, scale: 2),
                        IncludeGST = c.Boolean(nullable: false),
                        GST = c.Decimal(precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaterialPurchaseItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialPurchaseId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        GST = c.Decimal(precision: 18, scale: 2),
                        TotalAmount = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Document", "Expense_Id", "dbo.Expense");
            DropIndex("dbo.Document", new[] { "Expense_Id" });
            DropColumn("dbo.Employee", "TierType");
            DropColumn("dbo.Employee", "IsHavingDeduction");
            DropColumn("dbo.Employee", "ODDescription");
            DropColumn("dbo.Employee", "OADescription");
            DropColumn("dbo.Employee", "FixedDeduction");
            DropColumn("dbo.Employee", "OtherDeduction");
            DropColumn("dbo.Employee", "TransportDeduction");
            DropColumn("dbo.Employee", "HousingDeduction");
            DropColumn("dbo.Employee", "OtherAllowance");
            DropColumn("dbo.Employee", "TransportAllowance");
            DropColumn("dbo.Employee", "HousingAllowance");
            DropTable("dbo.Supplier");
            DropTable("dbo.Document");
            DropTable("dbo.Expense");
            CreateIndex("dbo.MaterialPurchaseItem", "MaterialPurchaseId");
            AddForeignKey("dbo.MaterialPurchaseItem", "MaterialPurchaseId", "dbo.MaterialPurchase", "Id");
        }
    }
}
