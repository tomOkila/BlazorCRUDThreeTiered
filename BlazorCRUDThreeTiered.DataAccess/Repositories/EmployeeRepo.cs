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
    public class EmployeeRepo(AppDbContext appDbContext) : IEmployee
    {
        public async Task<ServiceResponse> AddAsync(Employee employee)
        {
            var check = await appDbContext.Employees
                 .FirstOrDefaultAsync(_ => _.Name.ToLower() == employee.Name.ToLower());
            if (check != null)
                return new ServiceResponse(false, "User already exists");
            appDbContext.Employees.Add(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Added");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var employee = await appDbContext.Employees.FindAsync(id);
            if (employee == null)
                return new ServiceResponse(false, "User not found");
            appDbContext.Employees.Remove(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Deleted");
        }

        public async Task<List<Employee>> GetAsync() =>
            await appDbContext.Employees.OrderBy(i => i.Id)
            .AsNoTracking()
            .Include(gd => gd.Department)
            .ToListAsync();

        private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync();
        public async Task<Employee> GetByIdAsync(int id) =>
            await appDbContext.Employees.FindAsync(id);


        public async Task<ServiceResponse> UpdateAsync(Employee employee)
        {
            var emp = await appDbContext.Employees.FindAsync(employee.Id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.Name = employee.Name;
                emp.EmailAddress = employee.EmailAddress;
                emp.DepartmentId = employee.DepartmentId;
                emp.ProfilePic = employee.ProfilePic;
                //appDbContext.Update(employee);
                await SaveChangesAsync();
                return new ServiceResponse(true, "Updated");
            }

        }



        private static ServiceResponse NotFound() => new(false, "Sorry employee not found");
    }
}
