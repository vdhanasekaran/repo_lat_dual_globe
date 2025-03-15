using System;

namespace Library.DualGlobe.ERP.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
