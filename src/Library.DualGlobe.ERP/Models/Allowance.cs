using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DualGlobe.ERP.Models
{
    public class Allowance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ApprovedByEmployeeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime AllowanceDate { get; set; }
        public string AllowanceType { get; set; }
        public decimal? BonusAllowance { get; set; }
        public decimal? OtherAllowance { get; set; }
        public decimal? FoodAllowance { get; set; }
        public decimal? TravelAllowance { get; set; }
        public decimal? RoomRentalAllowance { get; set; }
        public decimal? IncentiveAllowance { get; set; }

        public virtual Employee employee { get; set; }
        
    }
}
