using BlazorCRUDThreeTiered.Business.DTOs;
using BlazorCRUDThreeTiered.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUDThreeTiered.DataAccess.Repositories
{
    public interface IDepartment
    {
        Task<ServiceResponse> AddAsync(Department department);
        Task<ServiceResponse> UpdateAsync(Department department);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<Department>> GetAsync();
        Task<Department> GetByIdAsync(int id);
    }
}
