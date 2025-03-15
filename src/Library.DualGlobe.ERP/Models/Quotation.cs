using System;
using System.Collections.Generic;

namespace Library.DualGlobe.ERP.Models
{
    public class Quotation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ReferenceNumber { get; set; }
        public string PONumber { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ValidUntil { get; set; }
        public string Stage { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string To { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string TermsAndCondtions { get; set; }
        public decimal? QuotationValue { get; set; }
        public string GSTType { get; set; }
        public decimal? GST { get; set; }
        public string DiscountType { get; set; }
        public decimal? DiscountValue { get; set; }
        public virtual List<QuotationItems> quotationItems { get; set; }
        public string CompanyName { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? ActualAmount { get; set; }

    }

    public class QuotationItems
    {
        public int Id { get; set; }
        public int? QuotationId { get; set; }
        public bool IsHeading { get; set; }
        public int? HeadingSortOrder { get; set; }
        public int? SortOrder { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Amount { get; set; }
        //public decimal? GST { get; set; }
    }
}
