// Professor.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace UniversityReportApp.Domain.Entities
{
    public class Professor : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; } // Додати по-батькові
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Report> Reports { get; set; }
    }
}
