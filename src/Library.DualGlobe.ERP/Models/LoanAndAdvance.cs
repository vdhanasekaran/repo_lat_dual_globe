using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DualGlobe.ERP.Models
{
    public class LoanAndAdvance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime LoanDate { get; set; }
        public decimal LoanAmount { get; set; }       
        public int ApprovedByEmployeeId { get; set; }
         [Column(TypeName = "date")]
        public DateTime LoanRepaymentStartDate { get; set; }
        public string Mode {get; set;}
         [Column(TypeName = "date")]
        public DateTime LoanRepaymentEndDate { get; set; }        
        public string LoanStatus { get; set; }
        public string RepaymentDuration { get; set; }
        public string RepaymentAmount { get; set; }

        public virtual Employee employee { get; set; }

        public virtual List<LoanAndAdvanceDetails> loanAndAdvanceDetails { get; set; }

    }

    public class LoanAndAdvanceDetails
    {
        public int Id { get; set; }        
        [Column(TypeName = "date")]
        public DateTime LoanDetectionDate { get; set; }
        public decimal LoanDetectionAmount { get; set; }
        public bool IsDetected { get; set; }

    }
}
