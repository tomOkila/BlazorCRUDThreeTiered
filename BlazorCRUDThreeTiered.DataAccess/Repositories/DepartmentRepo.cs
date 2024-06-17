using BlazorCRUDThreeTiered.Business.DTOs;
using BlazorCRUDThreeTiered.Business.Entities;
using BlazorCRUDThreeTiered.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUDThreeTiered.DataAccess.Repositories
{
    public class DepartmentRepo(AppDbContext appDbContext) : IDepartment
    {
        public async Task<ServiceResponse> AddAsync(Department department)
        {
            var check = await appDbContext.Departments
                .FirstOrDefaultAsync(_ => _.DepartmentName!.ToLower() == department.DepartmentName!.ToLower());
            if (check != null)
                return new ServiceResponse(false, "Department already exists");
            appDbContext.Departments.Add(department);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Added");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var department = await appDbContext.Departments.FindAsync(id);
            if (department == null)
                return new ServiceResponse(false, "Department not found");
            appDbContext.Departments.Remove(department);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Deleted");
        }

        public async Task<List<Department>> GetAsync() =>
              await appDbContext.Departments.AsNoTracking().ToListAsync();

        public async Task<Department> GetByIdAsync(int id) =>
            await appDbContext.Departments.FindAsync(id);

        public async Task<ServiceResponse> UpdateAsync(Department department)
        {
            appDbContext.Update(department);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Updated");
        }

        private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync();
    }
}
