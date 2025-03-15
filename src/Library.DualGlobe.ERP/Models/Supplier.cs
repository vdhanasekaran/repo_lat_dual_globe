using System;
using System.Collections.Generic;

namespace Library.DualGlobe.ERP.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string ContactPerson { get; set; }
    }
}
