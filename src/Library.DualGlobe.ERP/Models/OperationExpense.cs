using System;

namespace Library.DualGlobe.ERP.Models
{
    public class OperationExpense
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string BillRefNo { get; set; }
        public string ExpenseCategory { get; set; }
        public string OtherExpense { get; set; }
        public decimal? Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string TransRefNo { get; set; }
        public string PaymentStatus { get; set; }
    }
}
