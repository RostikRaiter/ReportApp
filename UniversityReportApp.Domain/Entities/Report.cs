// Report.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityReportApp.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int ProfessorId { get; set; } // Змінено з Guid на int
        public Professor Professor { get; set; }
    }
}
