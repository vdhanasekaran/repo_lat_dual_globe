namespace Library.DualGlobe.ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ERP7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InvoicePhase", "UnitPrice", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.InvoicePhase", "GST", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.InvoicePhase", "QuotationAmount", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.InvoicePhase", "PhaseAmount", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.InvoicePhase", "GSTAmount", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.InvoicePhase", "PhaseInvoiceAmount", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.InvoicePhase", "DiscountedGSTAmount", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.InvoicePhase", "DiscountedPhaseInvoiceAmount", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.Invoice", "TotalAmount", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.Invoice", "InvoiceAmount", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.Invoice", "TotalGSTAmount", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.Invoice", "TotalDiscountedGST", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.Invoice", "TotalDiscountedPhaseInvoice", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.Invoice", "DiscountValue", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.Invoice", "TotalPhaseAmount", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.QuotationItems", "UnitPrice", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.QuotationItems", "Amount", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.QuotationItems", "GST", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.Quotation", "QuotationValue", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.Quotation", "GST", c => c.Decimal(precision: 32, scale: 16));
            AlterColumn("dbo.Quotation", "DiscountValue", c => c.Decimal(precision: 32, scale: 16));
        }
        
        public override void Down()
        {
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
        }
    }
}
