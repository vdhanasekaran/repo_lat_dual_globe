using System;

namespace Library.DualGlobe.ERP.Models
{
    public class User
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }       
        public string IsActive { get; set; }
        public string Role { get; set; }

        public virtual Employee employee {get; set;}
    }
}
