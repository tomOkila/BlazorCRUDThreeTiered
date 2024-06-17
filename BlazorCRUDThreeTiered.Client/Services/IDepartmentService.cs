using BlazorCRUDThreeTiered.Business.DTOs;
using BlazorCRUDThreeTiered.Business.Entities;

namespace BlazorCRUDThreeTiered.Client.Services
{
    public interface IDepartmentService
    {
        Task<ServiceResponse> AddAsync(Department department);
        Task<ServiceResponse> UpdateAsync(Department department);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<Department>> GetAsync();
        Task<Department> GetByIdAsync(int id);
    }
}
