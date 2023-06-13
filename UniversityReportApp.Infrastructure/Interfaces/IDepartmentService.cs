using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityReportApp.Domain.Entities;

namespace UniversityReportApp.Infrastructure.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentAsync(int id);
        IQueryable<Department> GetDepartments();
        Task AddDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int id);
    }
}
