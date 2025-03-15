using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DualGlobe.ERP.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MenuURL { get; set; }
        public int ParentMenucode { get; set; }
        public string MenuType { get; set; }
    }
}
