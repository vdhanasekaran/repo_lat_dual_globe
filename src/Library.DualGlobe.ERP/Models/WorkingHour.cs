using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DualGlobe.ERP.Models
{
    public class WorkingHour
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public TimeSpan? InTime { get; set; }
        public TimeSpan? OutTime { get; set; }
        public decimal? TotalHour { get; set; }
        public decimal? WeeklyAvgWorkingHour { get; set; }
        public decimal? WeeklyAvgWorkingDays { get; set; }
    }
}
