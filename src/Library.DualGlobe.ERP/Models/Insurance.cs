using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DualGlobe.ERP.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public string InsuranceProviderName { get; set; }
        public string InsuranceType { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
