using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DualGlobe.ERP.Models
{
    public class Overtime
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string OTType { get; set; }
        public decimal? OTValue { get; set; }
    }
}
