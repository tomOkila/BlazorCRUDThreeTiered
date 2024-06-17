using BlazorCRUDThreeTiered.Business.DTOs;
using BlazorCRUDThreeTiered.Business.Entities;

namespace BlazorCRUDThreeTiered.Client.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResponse> AddAsync(Employee employee);
        Task<ServiceResponse> UpdateAsync(Employee employee);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<Employee>> GetAsync();
        Task<Employee> GetByIdAsync(int id);
    }
}
