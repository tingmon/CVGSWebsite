using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class Employee
    {
        public int PersonId { get; set; }
        public string Gln { get; set; }
        public string PositionCode { get; set; }
        public string PayCategoryCode { get; set; }
        public string DepartmentCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Note { get; set; }
        public string UserName { get; set; }

        public virtual Department DepartmentCodeNavigation { get; set; }
        public virtual Location GlnNavigation { get; set; }
        public virtual EmployeePayCategory PayCategoryCodeNavigation { get; set; }
        public virtual Person Person { get; set; }
        public virtual EmployeePosition PositionCodeNavigation { get; set; }
    }
}
