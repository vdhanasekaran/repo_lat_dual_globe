using System;
using System.Collections.Generic;

namespace Library.DualGlobe.ERP.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public int? ClientId { get; set; }
        public int? ProjectId { get; set; }
        public string Email { get; set; }
        public int? QuotationId { get; set; }
        public string Address { get; set; }
        public string Attention { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Status { get; set; }
        public string PhaseName { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? TotalGSTAmount { get; set; }
        public decimal? TotalDiscountedGST { get; set; }
        public decimal? TotalDiscountedPhaseInvoice { get; set; }
        public string IsProgressClaimRequired { get; set; }
        public string ProgressClaimStatus { get; set; }
        public string DiscountType { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? TotalPhaseAmount { get; set; }
        public virtual List<InvoicePhase> InvoicePhases { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public string CompanyName { get; set; }
        public string Subject { get; set; }
        public string PaymentInformation { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? ActualAmount { get; set; }
        public string GSTType { get; set; }
    }

    public class InvoicePhase
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Description { get; set; }
        public decimal? Percentage { get; set; }
        //public decimal? GST { get; set; }
        public decimal? QuotationAmount { get; set; }
        public decimal? PhaseAmount { get; set; }
        //public decimal? GSTAmount { get; set; }
        public decimal? PhaseInvoiceAmount { get; set; }
        //public decimal? DiscountedGSTAmount { get; set; }
        //public decimal? DiscountedPhaseInvoiceAmount { get; set; }
    }
}
