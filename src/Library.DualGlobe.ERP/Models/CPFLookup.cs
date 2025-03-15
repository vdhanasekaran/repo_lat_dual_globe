using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DualGlobe.ERP.Models
{
    public class CPFLookup
    {
        public int Id { get; set; }
        public int? AgeMinVal { get; set; }
        public int? AgeMaxVal { get; set; }
        public decimal? WageMinVal { get; set; }
        public decimal? WageMaxVal { get; set; }
        public decimal? TotalOWMaxVal { get; set; }
        public decimal? EmployeeOWMaxVal { get; set; }
        public string TotalCPF { get; set; }
        public string EmployeeCPF { get; set; }
        public string EmployeeStatus { get; set; }
        public int? CPFLookUpYear { get; set; }
        [Column(TypeName = "date")]
        public DateTime EffectiveDate { get; set; }

    }
}
