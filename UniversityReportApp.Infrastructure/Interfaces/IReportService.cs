using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityReportApp.Domain.Entities;

namespace UniversityReportApp.Infrastructure.Interfaces
{
    public interface IReportService
    {
        Task<Report> GetReportAsync(int id);
        IQueryable<Report> GetReports();
        Task AddReportAsync(Report report);
        Task UpdateReportAsync(Report report);
        Task DeleteReportAsync(int id);
    }
}
