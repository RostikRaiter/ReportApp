using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityReportApp.Domain.Entities
{
    public class Professor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }  // Додати по-батькові
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Report> Reports { get; set; }
    }

}
