using System;

namespace Library.DualGlobe.ERP.Models
{
    public class OtherIncome
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime IncomeDate { get; set; }
        public decimal? TotalAmount { get; set; }        
    }
}
