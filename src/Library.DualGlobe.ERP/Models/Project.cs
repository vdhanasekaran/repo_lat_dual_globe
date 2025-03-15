using System;
using System.ComponentModel.DataAnnotations;

namespace Library.DualGlobe.ERP.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        public virtual Client client { get; set; }
    }
}
