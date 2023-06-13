using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityReportApp.Domain.Entities;

namespace UniversityReportApp.Infrastructure.Interfaces
{
    public interface IFacultyService
    {
        Task<Faculty> GetFacultyAsync(int id);
        IQueryable<Faculty> GetFaculties();
        Task AddFacultyAsync(Faculty faculty);
        Task UpdateFacultyAsync(Faculty faculty);
        Task DeleteFacultyAsync(int id);
    }
}
