using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DualGlobe.ERP.Models
{
    public class RestDayPay
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string FullRestDayPayType { get; set; }
        public decimal? FullRestDayPayValue { get; set; }
        public string HalfRestDayPayType { get; set; }
        public decimal? HalfRestDayPayValue { get; set; }
    }
}
