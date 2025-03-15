using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DualGlobe.ERP.Models
{
    public class PublicHoliday
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public string LeaveDescription { get; set; }
        
    }
}
