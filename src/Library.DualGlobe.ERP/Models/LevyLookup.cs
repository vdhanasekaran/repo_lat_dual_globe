using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DualGlobe.ERP.Models
{
    public class LevyLookup
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime FromDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime ToDate { get; set; }
        public string Sector { get; set; }
        public string PassType { get; set; }
        public decimal? MYNHighSkilled { get; set; }
        public decimal? MYNBasicSkilled { get; set; }
        public decimal? MYNWaiverHighSkilled { get; set; }
        public decimal? MYNWaiverBasicSkilled { get; set; }
        public decimal? BasicTier { get; set; }
        public decimal? Tier2 { get; set; }

    }
}
