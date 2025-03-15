using System;
using System.Collections.Generic;

namespace Library.DualGlobe.ERP.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public DateTime? IncorporationDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Country { get; set; }
        public bool Status { get; set; }
        public string Currency { get; set; }
        public bool IsGSTRegistered { get; set; }
        public DateTime? GSTRegisterDate { get; set; }
        public string GSTNumber { get; set; }
        public string GSTType { get; set; }
        public string IndustryClassification { get; set; }
        public string CompanyType { get; set; }
        public DateTime? AccountingYearFromDate { get; set; }
        public DateTime? AccountingYearToDate { get; set; }
        public string CompanyLogo { get; set; }
    }
}
