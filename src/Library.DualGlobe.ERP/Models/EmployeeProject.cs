namespace Library.DualGlobe.ERP.Models
{
    public class EmployeeProject
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int projectId { get; set; }

        public virtual Employee employee { get; set; }

        public virtual Project project { get; set; }
    }
}
