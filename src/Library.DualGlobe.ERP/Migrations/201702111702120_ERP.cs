namespace Library.DualGlobe.ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ERP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeDocument",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(),
                        DocumentUrl = c.String(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyNumber = c.String(),
                        IncorporationDate = c.DateTime(),
                        Email = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        FaxNumber = c.String(),
                        Country = c.String(),
                        Status = c.Boolean(nullable: false),
                        Currency = c.String(),
                        IsGSTRegistered = c.Boolean(nullable: false),
                        GSTRegisterDate = c.DateTime(),
                        GSTNumber = c.String(),
                        GSTType = c.String(),
                        IndustryClassification = c.String(),
                        CompanyType = c.String(),
                        AccountingYearFromDate = c.DateTime(),
                        AccountingYearToDate = c.DateTime(),
                        CompanyLogo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Client", "FaxNumber", c => c.String());
            AlterColumn("dbo.InvoicePhase", "UnitPrice", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.InvoicePhase", "GST", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.InvoicePhase", "QuotationAmount", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.InvoicePhase", "PhaseAmount", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.InvoicePhase", "GSTAmount", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.InvoicePhase", "PhaseInvoiceAmount", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.InvoicePhase", "DiscountedGSTAmount", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.InvoicePhase", "DiscountedPhaseInvoiceAmount", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.Invoice", "TotalAmount", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.Invoice", "InvoiceAmount", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.Invoice", "TotalGSTAmount", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.Invoice", "TotalDiscountedGST", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.Invoice", "TotalDiscountedPhaseInvoice", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.Invoice", "DiscountValue", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.Invoice", "TotalPhaseAmount", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.QuotationItems", "UnitPrice", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.QuotationItems", "Amount", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.QuotationItems", "GST", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.Quotation", "QuotationValue", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.Quotation", "GST", c => c.Decimal(precision: 16, scale: 4));
            AlterColumn("dbo.Quotation", "DiscountValue", c => c.Decimal(precision: 16, scale: 4));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeDocument", "Employee_Id", "dbo.Employee");
            DropIndex("dbo.EmployeeDocument", new[] { "Employee_Id" });
            AlterColumn("dbo.Quotation", "DiscountValue", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Quotation", "GST", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Quotation", "QuotationValue", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.QuotationItems", "GST", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.QuotationItems", "Amount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.QuotationItems", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Invoice", "TotalPhaseAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Invoice", "DiscountValue", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Invoice", "TotalDiscountedPhaseInvoice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Invoice", "TotalDiscountedGST", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Invoice", "TotalGSTAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Invoice", "InvoiceAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Invoice", "TotalAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvoicePhase", "DiscountedPhaseInvoiceAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvoicePhase", "DiscountedGSTAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvoicePhase", "PhaseInvoiceAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvoicePhase", "GSTAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvoicePhase", "PhaseAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvoicePhase", "QuotationAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvoicePhase", "GST", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvoicePhase", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Client", "FaxNumber");
            DropTable("dbo.Company");
            DropTable("dbo.EmployeeDocument");
        }
    }
}
